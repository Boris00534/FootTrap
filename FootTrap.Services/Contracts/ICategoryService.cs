using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Contracts
{
    public interface ICategoryService
    {
        Task<List<string>> GetAllCategoriesAsync();
    }
}
