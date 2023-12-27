using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootTrap.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>

    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(GetCustomers());
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = "a3bd28c7-f6f8-4eb8-9ca3-d3539faf427e",
                    UserId = "ff2007b9-1919-4382-983f-a583d47b9040"
                }
            };
        }
    }
}
