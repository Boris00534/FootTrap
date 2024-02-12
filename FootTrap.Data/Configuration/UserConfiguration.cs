using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootTrap.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GetUsers());
        }

        private List<User> GetUsers()
        {
            var users = new List<User>();
            var passHasher = new PasswordHasher<User>();


            var user = new User()
            {
                Id = "ff2007b9-1919-4382-983f-a583d47b9040",
                FirstName = "Georgi",
                LastName = "Ivanov",
                Email = "georgiivanov@abv.bg",
                NormalizedEmail = "GEORGIIVANOV@ABV.BG",
                UserName = "gosho",
                NormalizedUserName = "GOSHO",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Al. Batenberg 15",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607793/FootTrapProject/5685_jb2zs0.jpg"
            };

            user.PasswordHash = passHasher.HashPassword(user, "123456");
            users.Add(user);

            var user2 = new User()
            {
                Id = "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                FirstName = "Boris",
                LastName = "Ivanov",
                Email = "borisivanov@abv.bg",
                NormalizedEmail = "BORISIVANOV@ABV.BG",
                UserName = "borkata",
                NormalizedUserName = "BORKATA",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Stefan Stambolov 20",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607775/FootTrapProject/2150771123_oytfrj.jpg"
            };

            user2.PasswordHash = passHasher.HashPassword(user2, "123456");
            users.Add(user2);


            return users;

        }
    }
}
