using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FootTrapDbContext context;

        public CategoryService(FootTrapDbContext context)
        {
            this.context = context;
        }
        public async Task<List<string>> GetAllCategoryNamesAsync()
        {
            var categories = await context.Category
                .Select(c => c.Name)
                .ToListAsync();

            return categories;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await context.Category
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id, 
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }
    }
}
