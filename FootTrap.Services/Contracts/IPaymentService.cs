using FootTrap.Services.ViewModels.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Contracts
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentAsync(PaymentFormModel model, string customerId);

        Task AddOrderToPaymentAsync(string paymentId, string orderId);
    }
}
