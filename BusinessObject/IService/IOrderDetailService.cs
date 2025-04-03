using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.IService
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int orderId, int productId);
        Task CreateOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int orderId, int productId);
    }
}
