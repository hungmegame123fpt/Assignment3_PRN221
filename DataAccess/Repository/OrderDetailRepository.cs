using DataAccess.Context;
using DataAccess.IRepository;
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
    }
}
