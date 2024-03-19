using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FootTrap.Test.UnitTest.DatabaseSeeder;

namespace FootTrap.Test.UnitTest
{
    public class CustomerServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private ICustomerService customerService;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.customerService = new CustomerService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task CreateAsyncShouldCreateCustomer()
        {
            var user = new User()
            {
                Id = "074c3126-71b7-4e88-99c3-288c976de678",
                FirstName = "Test",
                LastName = "Testov",
                Email = "testtestov@abv.bg",
                NormalizedEmail = "TESTTESTOV@ABV.BG",
                UserName = "test",
                NormalizedUserName = "TEST",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Stefan Stambolov 20",
                ProfilePictureUrl = "null"
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();


            await customerService.Create(user.Id);

            var result = await dbContext.Customers.AnyAsync(c => c.UserId ==  user.Id);

            Assert.True(result);
        }

        [Test]
        [TestCase("cf736628-fe9b-4e17-9fe9-cff2c3ce94a1")]
        public async Task GetCustomerIdByUserIdAsyncShouldReturnCorrectResult(string userId)
        {
            var result = await customerService.GetCustomerIdByUserIdAsync(userId);
            var expectedResult = "d1d73a5e-f042-436f-bcca-24b5537988e8";

            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("ccff2c3ce94a1")]
        [TestCase("null")]
        [TestCase("id")]
        public async Task GetCustomerIdByUserIdAsyncShouldReturnNull(string userId)
        {
            var result = await customerService.GetCustomerIdByUserIdAsync(userId);

            Assert.Null(result);

        }


    }
}
