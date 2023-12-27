using FootTrap.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GetCategories());
        }

        public ICollection<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = "aac323e4-7f49-4c33-abd1-ef8f3c74aa0c",
                    Name = "Mens"
                },
                new Category()
                {
                    Id = "80f954a9-4cd1-48d1-a2e4-e915db22e23e",
                    Name = "Women"
                },
                new Category()
                {
                    Id = "2e92eddd-98de-4e6a-a9cd-36042cc3066d",
                    Name = "Sport"
                }
            };

            return categories;
        }
    }
}
