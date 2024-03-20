using FootTrap.Data;
using FootTrap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Test.UnitTest
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(FootTrapDbContext context)
        {
            SeedUsers(context);
            SeedCustomer(context);
            SeedCategories(context);
            SeedShoes(context);
            SeedSizes(context);
            SeedSizeShoes(context);
            SeedOrder(context);
            SeedPayment(context);


            context.SaveChanges();
        }

        public static void SeedUsers(FootTrapDbContext context)
        {
            var user = new User()
            {
                Id = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1",
                FirstName = "Georgi",
                LastName = "Ivanov",
                Email = "georgiivanov@abv.bg",
                NormalizedEmail = "GEORGIIVANOV@ABV.BG",
                UserName = "gosho",
                NormalizedUserName = "GOSHO",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Al. Batenberg 15",
                PhoneNumber = "0889864831",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607793/FootTrapProject/5685_jb2zs0.jpg"
            };


            var admin = new User()
            {
                Id = "5ae09e63-5bd2-470e-ae11-f96a7469c78c",
                FirstName = "Boris",
                LastName = "Ivanov",
                Email = "borisivanov@abv.bg",
                NormalizedEmail = "BORISIVANOV@ABV.BG",
                UserName = "borkata",
                NormalizedUserName = "BORKATA",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Stefan Stambolov 20",
                PhoneNumber = "0889864821",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607775/FootTrapProject/2150771123_oytfrj.jpg"
            };

            context.Users.Add(user);
            context.Users.Add(admin);


        }

        public static void SeedCustomer(FootTrapDbContext context)
        {
            var customer = new Customer()
            {
                Id = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                UserId = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1",
                IsActive = true
            };

            context.Customers.Add(customer);
        }

        public static void SeedCategories(FootTrapDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = "08851195-d523-418f-b272-37c3d91544df",
                    Name = "Sports"
                },
                new Category()
                {
                    Id = "22ef8689-c7fa-4315-8505-377ece4c16ff",
                    Name = "Men"
                },
                new Category()
                {
                    Id = "2f22398c-dc3c-4d81-9a56-19a46252210c",
                    Name = "Women"
                },
                new Category()
                {
                    Id = "4874581a-3b02-41e0-bdca-07cf40545f88",
                    Name = "Kids"
                },

            };

            context.Category.AddRange(categories);
        }

        public static void SeedShoes(FootTrapDbContext context)
        {
            var shoe = new Shoe()
            {
                Id = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4",
                Name = "Test Shoe",
                CategoryId = "08851195-d523-418f-b272-37c3d91544df",
                Description = "test descritpion for shoe",
                Price = 13.3m,
                ShoeUrlImage = "image",
                IsActive = true
            };

            context.Shoes.Add(shoe);
        }

        public static void SeedSizes(FootTrapDbContext context)
        {
            var sizes = new List<Size>()
            {
                new Size()
                {
                    Id = 1,
                    Number = 40
                },
                new Size()
                {
                    Id = 2,
                    Number = 41
                },
                new Size()
                {
                    Id = 3,
                    Number = 42
                },
                new Size()
                {
                    Id = 4,
                    Number = 43
                },
                new Size()
                {
                    Id = 5,
                    Number = 44
                }

            };

            context.Sizes.AddRange(sizes);
        }

        public static void SeedSizeShoes(FootTrapDbContext context)
        {
            var sizesShoe = new List<SizeShoe>()
            {
                new SizeShoe()
                {
                    SizeId = 1,
                    ShoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4"
                },
                new SizeShoe()
                {
                    SizeId = 2,
                    ShoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4"
                },
                new SizeShoe()
                {
                    SizeId = 3,
                    ShoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4"
                },
                new SizeShoe()
                {
                    SizeId = 4,
                    ShoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4"
                },

            };

            context.SizeShoes.AddRange(sizesShoe);
        }

        public static void SeedOrder(FootTrapDbContext context)
        {
            var order = new Order()
            {
                Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                Status = "Waiting",
                CustomerId = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now.AddHours(1),
                DeliveryAddress = "Test address",
                Price = 120.0m,

            };

            context.Orders.AddRange(order);

        }

        public static void SeedPayment(FootTrapDbContext context)
        {
            var payment = new Payment()
            {
                Id = "c88747fc-4915-4b69-8f91-7758f8635f8e",
                CustomerId = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                OrderId = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                CardNumber = "0123456789101112",
                CardHolder = "Test Testov",
                ExpityDate = DateTime.Now.AddYears(2),
                SecurityCode = "8972"

            };

            context.Payments.Add(payment);
        }



    }
}
