using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Order;
using FootTrap.Services.ViewModels.Shoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FootTrap.Test.UnitTest.DatabaseSeeder;

namespace FootTrap.Test.UnitTest
{
    public class OrderServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private IOrderService orderService;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.orderService = new OrderService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddDeliveryTimeForOrderAsyncShouldAddDeliveryTime()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                CustomerName = "Test Testov", 
                OrderTime = "", 
                DeliveryAddress = "Test address", 
                Price = 120.0m, 
                Status = "Waiting", 
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            await orderService.AddDeliveryTimeForOrderAsync(model);

            var result = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == model.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.DeliveryTime, Is.EqualTo(model.DeliveryTime));

        }

        [Test]
        public async Task AddDeliveryTimeForOrderAsyncShouldDoNothig()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "73-4143-a728-d1d64a57e865",
                CustomerName = "Test Testov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            await orderService.AddDeliveryTimeForOrderAsync(model);

            var result = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == model.Id);

            Assert.That(result, Is.Null);

        }

        [Test]
        [TestCase("Accepted")]
        [TestCase("Delivered")]
        public async Task ChangeStatusOrderAsyncShouldChangeOrderStatus(string status)
        {
            string orderId = "7345f9f7-2e6f-4143-a728-d1d64a57e865";
            await orderService.ChangeStatusOrderAsync(orderId, status);

            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            Assert.That(order, Is.Not.Null);
            Assert.That(order.Status, Is.EqualTo(status));
        }

        [Test]
        [TestCase("Accepted")]
        [TestCase("Delivered")]
        public async Task ChangeStatusOrderAsyncShouldDoNothing(string status)
        {
            string orderId = "7345f9f7d64a57e865";
            await orderService.ChangeStatusOrderAsync(orderId, status);

            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            Assert.That(order, Is.Null);
        }

        [Test]
        public async Task CreateOrderAsyncShouldCreateOrder()
        {
            var payment = new Payment()
            {
                Id = "ca891e41-3e5a-4abd-ba6b-faae2b318ea3",
                CustomerId = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                CardNumber = "0123456789101112",
                CardHolder = "Test Testov",
                ExpityDate = DateTime.Now.AddYears(2),
                SecurityCode = "8972"

            };

            await dbContext.AddAsync(payment);
            await dbContext.SaveChangesAsync();


            OrderFormModel model = new OrderFormModel()
            {
                Address = "test order address", 
                City = "Kazanlak", 
                PaymentId = payment.Id,
                Shoes = new List<OrderShoeViewModel>()
                {
                    new OrderShoeViewModel()
                    {
                        Id = "9cb6c9ed-4bdc-4447-8aff-df120cc658a4",
                        Name = "Test Shoe",
                        Description = "test descritpion for shoe",
                        Price = 13.3m,
                        ShoeImageUrl = "null", 
                        Size = 40

                    }
                }

            };

            string customerId = "d1d73a5e-f042-436f-bcca-24b5537988e8";

            var result =  await orderService.CreateOrderAsync(model, customerId);


            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == result);

            Assert.That(order, Is.Not.Null);
        }

        [Test]
        public async Task EditDeliveryTimeForOrderAsyncShouldEditDeliveryTime()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                CustomerName = "Test Testov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            await orderService.EditDeliveryTimeForOrderAsync(model);

            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == model.Id);

            Assert.That(order, Is.Not.Null);
            Assert.That(order.DeliveryTime,  Is.EqualTo(model.DeliveryTime));

        }
        [Test]
        public async Task EditDeliveryTimeForOrderAsyncShouldDoNothing()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-2ed64a57e865",
                CustomerName = "Test Testov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            await orderService.EditDeliveryTimeForOrderAsync(model);

            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == model.Id);

            Assert.That(order, Is.Null);
        }

        [Test]
        public async Task GetAllOrdersAsyncShouldReturnCorrectResult()
        {
            var result = await orderService.GetAllOrdersAsync();

            var expectedResult = new List<OrderViewModel>()
            {
                new OrderViewModel()
                {
                    Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                    DeliveryAddress = "Test address", 
                    Status = "Waiting",
                    CustomerPhoneNumber = "0889864831", 
                    Price = 120.0m, 
                    OrderTime = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    DeliveryTime = DateTime.Now.AddHours(1).ToString("dddd, dd MMMM yyyy"),

                }
            };

            CollectionAssert.IsNotEmpty(result);
            CollectionAssert.IsNotEmpty(expectedResult);
            Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
        }

        [Test]
        public async Task GetCustomerOrdersAsyncShouldReturnCorrectResult()
        {
            string customerId = "d1d73a5e-f042-436f-bcca-24b5537988e8";
            var result = await orderService.GetCustomerOrdersAsync(customerId);

            var expectedResult = new List<OrderViewModel>()
            {
                new OrderViewModel()
                {
                    Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                    DeliveryAddress = "Test address",
                    Status = "Waiting",
                    CustomerPhoneNumber = "0889864831",
                    Price = 120.0m,
                    OrderTime = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    DeliveryTime = DateTime.Now.AddHours(1).ToString("dddd, dd MMMM yyyy"),

                }
            };

            CollectionAssert.IsNotEmpty(result);
            CollectionAssert.IsNotEmpty(expectedResult);
            Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
        }

        [Test]
        public async Task GetCustomerOrdersAsyncShouldReturnEmptyCollection()
        {
            string customerId = "d1d73a5e-f04237988e8";
            var result = await orderService.GetCustomerOrdersAsync(customerId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task GetOrderByIdAsyncShouldReturnCorrectResult()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                CustomerName = "Georgi Ivanov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            var result = await orderService.GetOrderByIdAsync(model.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(model.Id));
                Assert.That(result.CustomerName, Is.EqualTo(model.CustomerName));
                Assert.That(result.Status, Is.EqualTo(model.Status));
            });
        }

        [Test]
        public async Task GetOrderByIdAsyncShouldReturnNull()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f943-a728-d1d64a57e865",
                CustomerName = "Georgi Ivanov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            var result = await orderService.GetOrderByIdAsync(model.Id);

            Assert.That(result,  Is.Null);
        }

        [Test]
        public async Task GetOrderForEditShouldReturnCorrectResult()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-2e6f-4143-a728-d1d64a57e865",
                CustomerName = "Georgi Ivanov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            var result = await orderService.GetOrderForEditByIdAsync(model.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(model.Id));
                Assert.That(result.CustomerName, Is.EqualTo(model.CustomerName));
                Assert.That(result.Status, Is.EqualTo(model.Status));
            });

        }

        [Test]
        public async Task GetOrderForEditShouldReturnNull()
        {
            AcceptOrderFormModel model = new AcceptOrderFormModel()
            {
                Id = "7345f9f7-728-d1d64a57e865",
                CustomerName = "Georgi Ivanov",
                OrderTime = "",
                DeliveryAddress = "Test address",
                Price = 120.0m,
                Status = "Waiting",
                DeliveryTime = DateTime.Now.AddMinutes(30),
            };

            var result = await orderService.GetOrderForEditByIdAsync(model.Id);

            Assert.That(result, Is.Null);

        }

        [Test]
        public async Task IsOrderExistsByIsAsyncShouldReturnTrue()
        {
            string orderId = "7345f9f7-2e6f-4143-a728-d1d64a57e865";
            var result = await orderService.IsOrderExistsAsync(orderId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("")]
        [TestCase("null")]
        [TestCase("id")]
        public async Task IsOrderExistsByIsAsyncShouldReturnFalse(string orderId)
        {
            var result = await orderService.IsOrderExistsAsync(orderId);

            Assert.That(result, Is.False);
        }
    }
}
