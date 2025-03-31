using BusinessObject.IService;
using DataAccess.IRepository;
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
    }
}
