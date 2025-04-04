using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Order?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Order order, List<OrderDetail> orderDetails);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
