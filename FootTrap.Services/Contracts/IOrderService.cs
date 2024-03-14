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
        Task<string> CreateOrderAsync(OrderFormModel model, string cutomerId);

        Task<List<OrderViewModel>> GetCustomerOrdersAsync(string cutomerId);
        Task<List<OrderViewModel>> GetAllOrdersAsync();

        Task<bool> IsOrderExistsAsync(string orderId);

        Task ChangeStatusOrderAsync(string orderId, string status);

        Task AddDeliveryTimeForOrderAsync(AcceptOrderFormModel model);

        Task<AcceptOrderFormModel> GetOrderByIdAsync(string orderId);

    }
}
