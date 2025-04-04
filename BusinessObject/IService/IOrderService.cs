using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.IService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(Order order, List<OrderDetail> orderDetails);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
