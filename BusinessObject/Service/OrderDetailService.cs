using BusinessObject.IService;
using DataAccess.IRepository;
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
    }
}
