using FootTrap.Data;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Profile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Services
{
    public class ProfileService : IProfileService
    {
        private readonly FootTrapDbContext context;

        public ProfileService(FootTrapDbContext context)
        {
            this.context = context;
        }

        public async Task<ProfileViewModel?> GetProfileAsync(string userId)
        {
            var profile = await context.Customers
                .Include(c => c.User)
                .Where(u => u.UserId == userId)
                .Select(c => new ProfileViewModel()
                {
                    Id = c.UserId,
                    Name = $"{c.User.FirstName} {c.User.LastName}",
                    Email = c.User.Email, 
                    City = c.User.City,
                    Country = c.User.Country,
                    Address = c.User.Address,
                    PhoneNumber = c.User.PhoneNumber,
                    ProfilePictureUrl = c.User.ProfilePictureUrl

                })
                .FirstOrDefaultAsync();

            return profile;
        }
    }
}
