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
        private readonly IImageService imageService;

        public ProfileService(FootTrapDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }

        public async Task EditProfileAsync(string userId, EditProfileViewModel model)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Address = model.Address;
            user.Country = model.Country;
            user.City = model.City;
            user.PhoneNumber = model.Phone;

            if(model.ProfilePicture != null)
            {
                user.ProfilePictureUrl = await imageService.UploadImageToUser(model.ProfilePicture, "FootTrapProject", user);
            }

            await context.SaveChangesAsync();
           

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

        public async Task<EditProfileViewModel> GetProfileForEditAsync(string userId)
        {
            var profile = await context.Users
                .Where(u => u.Id == userId)
                .Select(u => new EditProfileViewModel()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    City = u.City,
                    Country = u.Country,
                    Address = u.Address,
                    Phone = u.PhoneNumber,
                    ProfilePictureUrl = u.ProfilePictureUrl
                })
                .FirstOrDefaultAsync();

            return profile!;
        }
    }
}
