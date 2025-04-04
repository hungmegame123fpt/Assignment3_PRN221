using DataAccess.Context;
using DataAccess.IRepository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductsRepository : IProductRepository
    {
        private FptEStoreDbContext _context;
        public ProductsRepository(FptEStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        } 
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> SearchAsync(string keyword)
        {
            return await _context.Products
                                 .Where(p => p.ProductName.Contains(keyword) ||
                                     p.UnitPrice.ToString().Contains(keyword))
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }
        public async Task<int> GetMaxProductIdAsync()
        {
            return await _context.Products.AnyAsync()
                ? await _context.Products.MaxAsync(m => m.ProductId)
                : 0;
        }
    }
}
