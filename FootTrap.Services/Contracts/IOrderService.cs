using FootTrap.Services.ViewModels.Order;
using FootTrap.Services.ViewModels.Shoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Contracts
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(OrderViewModel model, string cutomerId);
        
    }
}
