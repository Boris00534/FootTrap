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

        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderShoe> OrdersShoes { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Shoe> Shoes { get; set; } = null!;

        public DbSet<SizeShoe> SizeShoes { get; set; } = null!;

        public DbSet<Size> Sizes { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderShoe>()
                .HasKey(os => new { os.OrderId, os.ShoeId });
            builder.Entity<SizeShoe>()
                .HasKey(os => new { os.SizeId, os.ShoeId });


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
