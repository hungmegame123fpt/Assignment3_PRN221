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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private FptEStoreDbContext _context;
        public OrderDetailRepository(FptEStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                .ToListAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await _context.OrderDetails
                .Include(od => od.Product)
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(orderId, productId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
