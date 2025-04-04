using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> SearchAsync(string keyword);
        Task UpdateAsync(Product product);
        Task<int> GetMaxProductIdAsync();
    }
}
