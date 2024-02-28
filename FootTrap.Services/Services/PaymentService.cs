using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Payment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly FootTrapDbContext context;
        public PaymentService(FootTrapDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreatPaymentAsync(PaymentFormModel model, string customerId)
        {
            string[] el = model.ExpirationDate.Split('/');
            string expiryDate = $"01/{el[0]}/20{el[1]}";

            var payment = new Payment()
            {
                CardNumber = model.CardNumber,
                SecurityCode = model.SecurityCode,
                ExpityDate = DateTime.ParseExact(expiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                CardHolder = model.CardHolderName, 
                CustomerId = customerId,

            };

            await context.Payments.AddAsync(payment);
            await context.SaveChangesAsync();

            return payment.Id;
        }
    }
}
