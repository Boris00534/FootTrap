using FootTrap.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data.Configuration;

namespace FootTrap.Data
{
    public class FootTrapDbContext : IdentityDbContext<User>
    {
        private bool seedDb;
        public FootTrapDbContext(DbContextOptions<FootTrapDbContext> options, bool seedDb = true)
            : base(options)
        {

            this.seedDb = seedDb;

        }

        public FootTrapDbContext()
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderShoe> OrdersShoes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<Size> Sizes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderShoe>()
                .HasKey(os => new { os.OrderId, os.ShoeId });


            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());




            base.OnModelCreating(builder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
