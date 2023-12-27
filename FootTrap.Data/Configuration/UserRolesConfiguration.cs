using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootTrap.Data.Configuration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GetUserRoles());
        }

        private List<IdentityUserRole<string>> GetUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                    UserId = "ff2007b9-1919-4382-983f-a583d47b9040"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "599457c1-5737-4071-acbe-9f2cc064e41d",
                    UserId = "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3"
                }
            };
        }
    }
}
