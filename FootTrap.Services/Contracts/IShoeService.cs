using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Services.ViewModels.Shoes;

namespace FootTrap.Services.Contracts
{
    public interface IShoeService
    {
        Task<AllShoesFilteredAndPaged> GetAllShoesFilteredAndPagedAsync(ShoesQueryModel model);
    }
}
