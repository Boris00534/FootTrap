using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Category;
using FootTrap.Services.ViewModels.Shoes;
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
    public class ShoeServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private IShoeService shoeService;
        private IMock<IImageService> imageServiceMock;
        private IMock<IHttpContextAccessor> accessor;

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
            this.accessor = new Mock<IHttpContextAccessor>();

            this.shoeService = new ShoeService(this.dbContext, imageServiceMock.Object, accessor.Object);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        [TestCase("Test Shoe")]
        [TestCase("Test")]
        [TestCase("Shoe")]

        public async Task GetAllShoesFilteredAndPagedAsync(string searchString)
        {
            ShoesQueryModel model = new ShoesQueryModel() 
            {
                Category = "Sports",
                SearchString = searchString, 
            };

            var result = await shoeService.GetAllShoesFilteredAndPagedAsync(model);

            var expectedResult = new AllShoesFilteredAndPaged()
            {
                Shoes = new List<ShoeViewModel>()
                {
                    new ShoeViewModel()
                    {
                        Id = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4",
                        Name = "Test Shoe",
                        Price = 13.3m,
                        ShoePictureUrl = "image",
                        Description = "test descritpion for shoe",
                    }
                },
                TotalShoes = 1
            };

            Assert.That(result.TotalShoes, Is.EqualTo(expectedResult.TotalShoes));
            Assert.That(result.Shoes.ToList()[0].Name, Is.EqualTo(result.Shoes.ToList()[0].Name));
            Assert.That(result.Shoes.ToList()[0].Id, Is.EqualTo(result.Shoes.ToList()[0].Id));
        }

        [Test]
        public async Task AddAsyncShouldAddShoeCorrectly()
        {
            ShoeFormModel model = new ShoeFormModel()
            {
                Name = "Test add shoe",
                Description = "description for test shoe",
                Price = "40",
                CategoryId = "08851195-d523-418f-b272-37c3d91544df",

            };

            var result = await shoeService.AddAsync(model);

            var expectedResult = await dbContext.Shoes.FirstOrDefaultAsync(s => s.Id == result);

            Assert.That(expectedResult, Is.Not.Null);
            Assert.That(expectedResult.Name, Is.EqualTo(model.Name));
            Assert.That(expectedResult.Description, Is.EqualTo(model.Description));
        }

        [Test]
        public async Task GetDetailsForShoeAsyncShouldReturnCorrectResult()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var result = await shoeService.GetDetailsForShoeAsync(shoeId);

            var expectedResult = new DetailsShoeViewModel()
            {
                Id = shoeId,
                Name = "Test Shoe",
                Description = "test descritpion for shoe",
                Price = 13.3m,
                Category = "Sports",
                ShoePictureUrl = "image", 

            };

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(shoeId));
                Assert.That(result.Name, Is.EqualTo(expectedResult.Name));
                Assert.That(result.Description, Is.EqualTo(expectedResult.Description));
            });
        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task GetDetailsForShoeAsyncShouldReturnNull(string shoeId)
        {
            var result = await shoeService.GetDetailsForShoeAsync(shoeId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task IsShoeExistsAsyncShouldReturnTrue()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var result = await shoeService.IsExistsAsync(shoeId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task IsShoeExistsAsyncShouldReturnFalse(string shoeId)
        {
            var result = await shoeService.IsExistsAsync(shoeId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetShoeForEditAsyncShouldReturnCorrectResult()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var shoe = new ShoeFormModel()
            {
                Name = "Test Shoe",
                Description = "test descritpion for shoe",
                Price = "13.3",

            };

            shoe.Categories = new List<CategoryViewModel>()
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

            shoe.Sizes = new List<SizeViewModel>()
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
                new SizeViewModel()
                {
                    Id = 5,
                    Number = 44
                }
            };

            var result = await shoeService.GetShoeForEditAsync(shoeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Name, Is.EqualTo(shoe.Name));
                Assert.That(result.Description, Is.EqualTo(shoe.Description));
                Assert.That(result.Sizes.ToList()[0].Id, Is.EqualTo(shoe.Sizes.ToList()[0].Id));
                Assert.That(result.Categories.ToList()[0].Id, Is.EqualTo(shoe.Categories.ToList()[0].Id));
            });
        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task GetShoeForEditAsyncShouldNull(string shoeId)
        {
            var result = await shoeService.GetShoeForEditAsync(shoeId);

            Assert.Null(result);
        }

        [Test]
        public async Task GetShoeForOrderAsyncShouldReturnCorrectResult()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var expectedResult = new OrderShoeViewModel()
            {
                Id = shoeId,
                Name = "Test Shoe",
                Description = "test descritpion for shoe",
                Price = 13.3m,
                Size = 42,
                ShoeImageUrl = "image",
                IsEnabled = true,
            };

            var result = await shoeService.GetShoeForOrderAsync(shoeId, 42);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(expectedResult.Id));
                Assert.That(result.Name, Is.EqualTo(expectedResult.Name));
                Assert.That(result.Description, Is.EqualTo(expectedResult.Description));
            });

        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task GetShoeForOrderAsyncShouldReturnNull(string shoeId)
        {
            var result = await shoeService.GetShoeForOrderAsync(shoeId, 42);

            Assert.Null(result);
        }

        [Test]
        public async Task EditShoeAsyncShouldEditShoeCorrectly()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var shoe = new ShoeFormModel()
            {
                Name = "Test Shoe",
                Description = "test descritpion for shoe",
                Price = "13",
                SizeIds = new List<int>() { 1, 2, 3 }, 
                CategoryId = "08851195-d523-418f-b272-37c3d91544df"

            };

            await shoeService.EditShoeAsync(shoe, shoeId);

            var result = await dbContext.Shoes.FirstOrDefaultAsync(sh => sh.Id == shoeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(shoe.Name));
                Assert.That(result.Description, Is.EqualTo(shoe.Description));
                Assert.That(result.CategoryId, Is.EqualTo(shoe.CategoryId));
            });
        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task EditShoeAsyncShouldDoNothing(string shoeId)
        {
            var shoe = new ShoeFormModel()
            {
                Name = "Test Shoe",
                Description = "test descritpion for shoe",
                Price = "13",
                SizeIds = new List<int>() { 1, 2, 3 },
                CategoryId = "08851195-d523-418f-b272-37c3d91544df"

            };

            await shoeService.EditShoeAsync(shoe, shoeId);

            var result = await dbContext.Shoes.FirstOrDefaultAsync(sh => sh.Id == shoeId);

            Assert.That(result, Is.Null);


        }

        [Test]
        public async Task GetShoeForDeleteAsyncShouldReturnCorrectResult()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            var result = await shoeService.GetShoeForDeleteAsync(shoeId);

            PreDeleteShoeViewModel shoe = new PreDeleteShoeViewModel()
            {
                Id = shoeId,
                Name = "Test Shoe",
                Category = "Sports",
                Description = "test descritpion for shoe",
                Price = 13.3m,
                ShoePictureUrl = "image"
            };

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(shoeId));
                Assert.That(result.Name, Is.EqualTo(shoe.Name));
                Assert.That(result.Category, Is.EqualTo(shoe.Category));
            });
        }

        [Test]
        [TestCase("id")]
        [TestCase("name")]
        [TestCase("description")]
        public async Task GetShoeForDeleteAsyncShouldReturnNull(string shoeId)
        {
            var result = await shoeService.GetShoeForDeleteAsync(shoeId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteShoeAsyncShouldDeleteShoe()
        {
            string shoeId = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4";

            await shoeService.DeleteShoeAsync(shoeId);

            var result = await dbContext.Shoes.Where(sh => sh.IsActive).FirstOrDefaultAsync(sh => sh.Id == shoeId);

            Assert.That(result, Is.Null);
        }

    }
}
