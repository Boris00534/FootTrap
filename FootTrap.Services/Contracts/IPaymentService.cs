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
        Task<string> CreatPaymentAsync(PaymentFormModel model, string customerId);
    }
}
