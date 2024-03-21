using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Size;
using Microsoft.AspNetCore.Http;
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
    public class SizeServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private ISizeService sizeService;
      

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.sizeService = new SizeService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddSizesToShoeAsyncShouldAddSizesToShoe()
        {

            var shoe = new Shoe()
            {
                Id = "169924ee-4928-4bdd-ba72-2f5acbd05020",
                Name = "Test Shoe",
                CategoryId = "08851195-d523-418f-b272-37c3d91544df",
                Description = "test descritpion for shoe",
                Price = 13.3m,
                ShoeUrlImage = "image",
                IsActive = true
            };

            await dbContext.AddAsync(shoe);
            await dbContext.SaveChangesAsync();

            var sizes = new List<int>() { 1, 2, 3 };

            var shoeModel = await dbContext.Shoes
                .Include(s => s.SizeShoe)
                .FirstOrDefaultAsync(s => s.Id == shoe.Id);


            await sizeService.AddSizesToShoeAsync(sizes, shoe.Id);

            Assert.IsNotNull(shoe);
            Assert.That(shoe.SizeShoe.ToList()[0].SizeId, Is.EqualTo(sizes[0]));
        }

        [Test]

        public async Task GetAllSizesAsyncShouldReturnCorrectResult()
        {
            var result = await sizeService.GetAllSizesAsync();

            var expectedResult = new List<SizeViewModel>()
            {
                new SizeViewModel()
                {
                    Id = 1,
                    Number = 40
                },
                new SizeViewModel()
                {
                    Id = 2,
                    Number = 41
                },
                new SizeViewModel()
                {
                    Id = 3,
                    Number = 42
                },
                new SizeViewModel()
                {
                    Id = 4,
                    Number = 43
                },
            };

            Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
        }

    }
}
