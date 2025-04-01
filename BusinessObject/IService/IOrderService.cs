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
    }
}
