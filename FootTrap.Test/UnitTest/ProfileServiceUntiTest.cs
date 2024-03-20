using FootTrap.Data;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Profile;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FootTrap.Test.UnitTest.DatabaseSeeder;

namespace FootTrap.Test.UnitTest
{
    [TestFixture]
    public class ProfileServiceUntiTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private IProfileService profileService;
        private IMock<IImageService> imageServiceMock;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.imageServiceMock = new Mock<IImageService>();

            this.profileService = new ProfileService(this.dbContext, imageServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task EditProfileAsyncShouldEditProfileCorrectly()
        {
            string userId = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1";
            EditProfileViewModel model = new EditProfileViewModel()
            {
                FirstName = "Ivan", 
                LastName = "Ivanov", 
                Email = "ivanIvanov@abv.bg", 
                City = "Kazanlak", 
                Country = "Bulgaria", 
                Address = "test address", 
                Phone = "0889764536", 
                ProfilePictureUrl = "null"
            };

            await profileService.EditProfileAsync(userId, model);

            var profile = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            Assert.Multiple(() =>
            {
                Assert.That(profile.FirstName, Is.EqualTo(model.FirstName));
                Assert.That(profile.LastName, Is.EqualTo(model.LastName));
                Assert.That(profile.Email, Is.EqualTo(model.Email));
                Assert.That(profile.City, Is.EqualTo(model.City));
            });
        }

        [Test]
        [TestCase("null")]
        [TestCase("id")]
        [TestCase("112")]
        public async Task EditProfileAsyncShouldDoNothing(string userId)
        {
            EditProfileViewModel model = new EditProfileViewModel()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanIvanov@abv.bg",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "test address",
                Phone = "0889764536",
                ProfilePictureUrl = "null"
            };

            await profileService.EditProfileAsync(userId, model);

            var profile = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            Assert.That(profile, Is.Null);
        }

        [Test]
        public async Task GetProfileAsyncShouldReturnCorrectResult()
        {
            string userId = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1";
            var model = new ProfileViewModel()
            {
                Id = userId,
                Name = "Georgi Ivanov",
                Email = "georgiivanov@abv.bg",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Al. Batenberg 15",
                PhoneNumber = "0889864831",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607793/FootTrapProject/5685_jb2zs0.jpg"
            };

            var result = await profileService.GetProfileAsync(userId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Name, Is.EqualTo(model.Name));
                Assert.That(result.City, Is.EqualTo(model.City));
                Assert.That(result.Country, Is.EqualTo(model.Country));
                Assert.That(result.Address, Is.EqualTo(model.Address));
            });

        }

        [Test]
        [TestCase("null")]
        [TestCase("id")]
        [TestCase("112")]
        public async Task GetProfileAsyncShouldReturnNull(string userId)
        {
            var result = await profileService.GetProfileAsync(userId);

            Assert.Null(result);
        }

        [Test]
        public async Task GetProfileForEditAsyncShouldReturnCorrectResult()
        {
            string userId = "cf736628-fe9b-4e17-9fe9-cff2c3ce94a1";
            var model = new EditProfileViewModel()
            {
                FirstName = "Georgi",
                LastName = "Ivanov",
                Email = "georgiivanov@abv.bg",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "ul. Al. Batenberg 15",
                Phone = "0889864831",
                ProfilePictureUrl = "https://res.cloudinary.com/dwocfg6qw/image/upload/v1703607793/FootTrapProject/5685_jb2zs0.jpg"
            };

            var result = await profileService.GetProfileForEditAsync(userId);

            Assert.Multiple(() =>
            {
                Assert.That(result.FirstName, Is.EqualTo(model.FirstName));
                Assert.That(result.LastName, Is.EqualTo(model.LastName));
                Assert.That(result.Email, Is.EqualTo(model.Email));
                Assert.That(result.City, Is.EqualTo(model.City));
            });
        }

        [Test]
        [TestCase("null")]
        [TestCase("id")]
        [TestCase("112")]
        public async Task GetProfileForEditAsyncShouldReturnNull(string userId)
        {
            var result = await profileService.GetProfileForEditAsync(userId);

            Assert.Null(result);
        }
    }
}
