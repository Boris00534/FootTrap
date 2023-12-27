using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Services.Contracts;
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
        public async Task<List<string>> GetAllCategoriesAsync()
        {
            var categories = await context.Category
                .Select(c => c.Name)
                .ToListAsync();

            return categories;
        }
    }
}
