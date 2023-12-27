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
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(GetRoles());
        }

        private List<IdentityRole> GetRoles()
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"

                },
                new IdentityRole()
                {
                    Id = "599457c1-5737-4071-acbe-9f2cc064e41d",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };

            return roles;


        }
    }
}
