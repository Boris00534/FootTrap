﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Services.ViewModels.Category;

namespace FootTrap.Services.Contracts
{
    public interface ICategoryService
    {
        Task<List<string>> GetAllCategoryNamesAsync();

        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
