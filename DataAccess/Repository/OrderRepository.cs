using DataAccess.Context;
using DataAccess.IRepository;
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
    }
}
