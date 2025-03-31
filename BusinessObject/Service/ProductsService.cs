using BusinessObject.IService;
using DataAccess.IRepository;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
    public class ProductsService : IProductsService
    {
        private IProductRepository _repo;
        public ProductsService(IProductRepository repo)
        {
            _repo = repo;
        }

    }
}
