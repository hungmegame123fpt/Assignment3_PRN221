using DataAccess.Context;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private FptEStoreDbContext _context;
        public CategoryRepository(FptEStoreDbContext context)
        {
            _context = context;
        }
    }
}
