using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Services.ViewModels.Size;

namespace FootTrap.Services.Contracts
{
    public interface ISizeService
    {
        Task<List<SizeViewModel>> GetAllSizesAsync();

        Task AddSizesToShoeAsync(List<int> sizesIds, string shoeId);
    }
}
