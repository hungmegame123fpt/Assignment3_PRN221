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
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository _repo;
        public OrderDetailService(IOrderDetailRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _repo.GetAllOrderDetailsAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await _repo.GetOrderDetailByIdAsync(orderId, productId);
        }

        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _repo.AddOrderDetailAsync(orderDetail);
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _repo.UpdateOrderDetailAsync(orderDetail);
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            await _repo.DeleteOrderDetailAsync(orderId, productId);
        }
        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _repo.GetOrderDetailByOrderIdAsync(orderId);
        }
    }
}
