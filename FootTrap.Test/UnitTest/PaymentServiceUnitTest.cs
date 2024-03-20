using CloudinaryDotNet.Actions;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Payment;
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
    public class PaymentServiceUnitTest
    {
        private DbContextOptions<FootTrapDbContext> dbOptions;
        private FootTrapDbContext dbContext;
        private IPaymentService paymentService;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FootTrapDbContext>()
                    .UseInMemoryDatabase("FootTrapInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FootTrapDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.paymentService = new PaymentService(this.dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddOrderToPaymentAsyncShouldReturnCorrectResult()
        {
            var order = new Order()
            {
                Id = "de5c3a0f-a366-43e5-8edf-3c41732e2680",
                Status = "Waiting",
                CustomerId = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now.AddHours(1),
                DeliveryAddress = "Test address",
                Price = 100.0m

            };

            var payment = new Payment()
            {
                Id = "ca891e41-3e5a-4abd-ba6b-faae2b318ea3",
                CustomerId = "d1d73a5e-f042-436f-bcca-24b5537988e8",
                CardNumber = "0123456789101112",
                CardHolder = "Test Testov",
                ExpityDate = DateTime.Now.AddYears(2),
                SecurityCode = "8972"

            };

            await dbContext.AddAsync(order);
            await dbContext.AddAsync(payment);

            await dbContext.SaveChangesAsync();

            await paymentService.AddOrderToPaymentAsync(payment.Id, order.Id);

            var result = await dbContext.Payments.FirstOrDefaultAsync(o => o.Id == payment.Id);

            Assert.IsNotNull(result);
            Assert.That(result.OrderId, Is.EqualTo(order.Id));


            
        }

        [Test]
        [TestCase("someId")]
        [TestCase("ca891e41-3e5a-4abd-ba6b-faae2b318ea3")]
        public async Task AddOrderToPaymentAsyncShouldDoNothing(string paymentId)
        {
            string orderId = Guid.NewGuid().ToString();

            await paymentService.AddOrderToPaymentAsync(paymentId, orderId);

            var result = await dbContext.Payments.FirstOrDefaultAsync(o => o.Id == paymentId);

            Assert.IsNull(result);

        }

        [Test]
        public async Task CreatPaymentAsyncShouldCreatePaymentCorrectly()
        {
            PaymentFormModel model = new PaymentFormModel()
            {
                CardHolderName = "Test testov", 
                CardNumber = "01234567891011", 
                ExpirationDate = "02/25", 
                SecurityCode = "9876"
            };

            string customerId = "d1d73a5e-f042-436f-bcca-24b5537988e8";

            var result = await paymentService.CreatePaymentAsync(model, customerId);

            var expectedResult = await dbContext.Payments.AnyAsync(p => p.Id == result);

            Assert.IsNotNull(result);
            Assert.That(expectedResult, Is.True);
        }
    }
}
