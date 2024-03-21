using FootTrap.Data;
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
    [TestFixture]
    public class UserServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private IUserService userService;


        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task ExistsByEmailAsyncShouldReturnTrue()
        {
            string email = "georgiivanov@abv.bg";

            var result = await userService.ExistsByEmailAsync(email);

            Assert.True(result);
        }

        [Test]
        [TestCase("Test@abv.bg")]
        [TestCase("test@abv.bg")]
        [TestCase("iavn@abv.bg")]
        public async Task ExistsByEmailAsyncShouldReturnFalse(string email)
        {
            var result = await userService.ExistsByEmailAsync(email);

            Assert.False(result);
        }


        [Test]
        public async Task ExistsByPhoneAsyncShouldReturnTrue()
        {
            string phone = "0889864831";

            var result = await userService.ExistsByPhoneAsync(phone);

            Assert.True(result);

        }

        [Test]
        [TestCase("0889875674")]
        [TestCase("0889653245")]
        [TestCase("0987645632")]
        public async Task ExistsByPhoneAsyncShouldReturnFalse(string phone)
        {
            var result = await userService.ExistsByPhoneAsync(phone);

            Assert.False(result);
        }

        [Test]
        public async Task IsCustomerAsyncShouldReturnTrue()
        {
            string userId = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1";

            var result = await userService.IsCustomerAsync(userId);

            Assert.True(result);
        }

        [Test]
        [TestCase("5ae09e63-5bd2-470e-ae11-f96a7469c78c")]
        [TestCase("someid")]
        [TestCase("047hfibvrcij3bq2ijbhuc-efwkjib")]
        public async Task IsCustomerShouldReturnFalse(string userId)
        {
            var result = await userService.IsCustomerAsync(userId);

            Assert.False(result);
        }

        [Test]
        [TestCase("cf736628-fe9b-4e17-9fe9-cff2c3ce94a1")]
        [TestCase("5ae09e63-5bd2-470e-ae11-f96a7469c78c")]
        public async Task IsExistsByIdAsyncShouldReturnTrue(string userId)
        {
            var result = await userService.IsExistsByIdAsync(userId);

            Assert.True(result);
        }

        [Test]
        [TestCase("5ae09e63-5bd2-470e-ae11-f96a7469c79c")]
        [TestCase("someid")]
        [TestCase("047hfibvrcij3bq2ijbhuc-efwkjib")]
        public async Task IsExistsByIdAsyncShouldReturnFalse(string userId)
        {
            var result = await userService.IsExistsByIdAsync(userId);

            Assert.False(result);
        }


    }
}
