using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Category;
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
    public class CategoryServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private ICategoryService categoryService;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }


        [Test]
        public async Task GetAllCategoryNameShouldReturnCurrectResult()
        {
            var result = await categoryService.GetAllCategoryNamesAsync();
            var expectedResult = new List<string>() { "Sports", "Men", "Women", "Kids"};

            Assert.Multiple(() =>
            {
                CollectionAssert.IsNotEmpty(result);
                CollectionAssert.AreEqual(expectedResult, result);
            });
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldReturnCorrectResult()
        {
            var result = await categoryService.GetAllCategoriesAsync();
            var expectedResult = new List<CategoryViewModel>()
            {
                new CategoryViewModel()
                {
                    Id = "08851195-d523-418f-b272-37c3d91544df",
                    Name = "Sports"
                },
                new CategoryViewModel()
                {
                    Id = "22ef8689-c7fa-4315-8505-377ece4c16ff",
                    Name = "Men"
                },
                new CategoryViewModel()
                {
                    Id = "2f22398c-dc3c-4d81-9a56-19a46252210c",
                    Name = "Women"
                },
                new CategoryViewModel()
                {
                    Id = "4874581a-3b02-41e0-bdca-07cf40545f88",
                    Name = "Kids"
                },
            };

            Assert.Multiple(() =>
            {
                CollectionAssert.IsNotEmpty(result);
                Assert.That(result[0].Name, Is.EqualTo(expectedResult[0].Name));
            });
        }

    }
}
