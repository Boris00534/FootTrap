using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class UserService : IUserService
    {
        private readonly FootTrapDbContext context;

        public UserService(FootTrapDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var user = await context.Users.AnyAsync(u => u.Email == email);

            return user;
        }

        public async Task<bool> ExistsByPhoneAsync(string phone)
        {
            var user = await context.Users.AnyAsync(u => u.PhoneNumber == phone);

            return user;
        }

        public async Task<bool> IsCustomerAsync(string userId)
        {
            bool isCustomer = await context.Customers.AnyAsync(c => c.IsActive && c.UserId == userId);

            return isCustomer;
        }

    }
}
