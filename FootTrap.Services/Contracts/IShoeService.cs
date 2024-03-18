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

        Task<string> AddAsync(ShoeFormModel model);

        Task<DetailsShoeViewModel> GetDetailsForShoeAsync(string shoeId);

        Task<bool> IsExistsAsync(string id);

        List<OrderShoeViewModel>? GetCartShoes(string username);

        Task<OrderShoeViewModel> GetShoeForOrderAsync(string shoeId, int size);

        Task AddShoeToCart(string username, string shoeId, int size);

        Task<ShoeFormModel> GetShoeForEditAsync(string shoeId);

        Task EditShoeAsync(ShoeFormModel shoe, string shoeId);

        Task<PreDeleteShoeViewModel> GetShoeForDeleteAsync(string shoeId);

        Task DeleteShoeAsync(string shoeId);
    }
}
