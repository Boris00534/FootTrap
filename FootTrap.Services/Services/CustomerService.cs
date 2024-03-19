using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class CustomerService : ICustomerService

    {
        private readonly FootTrapDbContext context;

        public CustomerService(FootTrapDbContext context)
        {
            this.context = context;
        }

        public async Task Create(string userId)
        {
            var customer = new Customer()
            {
                UserId = userId,
            };

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task<string?> GetCustomerIdByUserIdAsync(string userId)
        {
            var customer = await context.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return customer?.Id;
        }
    }
}
