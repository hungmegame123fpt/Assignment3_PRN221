using BusinessObject.IService;
using DataAccess.IRepository;
using DataAccess.Models;
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
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            product.ProductId = await GenerateUniqueProductId();
            await _repo.CreateAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _repo.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            return await _repo.SearchAsync(keyword);
        }
        private async Task<int> GenerateUniqueProductId()
        {
            var maxId = await _repo.GetMaxProductIdAsync();
            return maxId + 1;
        }
    }
}
