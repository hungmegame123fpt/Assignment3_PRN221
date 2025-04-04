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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllAsync();
        }
        public async Task CreateCategoryAsync(Category category)
        {
            await _repo.CreateAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _repo.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repo.DeleteAsync(categoryId);
        }
    }
}