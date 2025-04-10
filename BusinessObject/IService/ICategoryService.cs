﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}