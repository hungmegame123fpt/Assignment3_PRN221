using BusinessObject.IService;
using DataAccess.IRepository;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _repo;
        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _repo.GetOrdersByDateRangeAsync(startDate, endDate);
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order, List<OrderDetail> orderDetails)
        {
            return await _repo.CreateAsync(order, orderDetails);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _repo.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
        public async Task<List<Order>> GetOrdersByMemberId(int memberId)
        {
            return await _repo.GetMemberOrders(memberId);
        }
    }
}
