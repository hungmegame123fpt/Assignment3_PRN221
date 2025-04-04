using DataAccess.Context;
using DataAccess.IRepository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private FptEStoreDbContext _context;
        public OrderRepository(FptEStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Include(o => o.Member)
                .Where(o => o.OrderDate.Date >= startDate.Date && o.OrderDate.Date <= endDate.Date)
                .ToListAsync();
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Member)
                .FirstOrDefaultAsync(p => p.OrderId == id);
        }
        public async Task<bool> CreateAsync(Order order, List<OrderDetail> orderDetails)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                order.OrderId = await GetMaxOrderIdAsync() + 1;
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                foreach (var orderDetail in orderDetails)
                {
                    // Fetch Product from Database
                    var product = await _context.Products.FindAsync(orderDetail.ProductId);
                    if (product == null || product.UnitsInStock < orderDetail.Quantity)
                    {
                        throw new InvalidOperationException($"Not enough stock for Product ID {orderDetail.ProductId}");
                    }

                    // Reduce Stock
                    product.UnitsInStock -= orderDetail.Quantity;
                    _context.Products.Update(product);

                    // Add OrderDetail
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.UnitPrice = product.UnitPrice;
                    await _context.OrderDetails.AddAsync(orderDetail);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync(); 
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetMaxOrderIdAsync()
        {
            return await _context.Orders.AnyAsync()
                ? await _context.Orders.MaxAsync(m => m.OrderId)
                : 0;
        }

    }
}
