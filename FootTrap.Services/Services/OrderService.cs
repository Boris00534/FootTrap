using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Data.Models.Enums;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly FootTrapDbContext context;
        public OrderService(FootTrapDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreateOrderAsync(OrderViewModel model, string customerId)
        {
            var order = new Order()
            {
                CustomerId = customerId,
                Status = OrderStatusEnum.Waiting.ToString(),
                OrderTime = DateTime.Now,
                DeliveryAddress = model.Address,
                Price = (decimal)(model.Shoes.Select(d => d.Price).Sum() +
                0.05m * model.Shoes.Select(d => d.Price).Sum() + 5)!,
                PaymentId = model.PaymentId,

            };

            List<OrderShoe> orderShoes = new();
            foreach(var shoe in model.Shoes)
            {
                OrderShoe sho = new OrderShoe()
                {
                    OrderId = order.Id,
                    ShoeId = shoe.Id,
                };

                orderShoes.Add(sho);
            }

            order.OrderShoe = orderShoes;

            await context.Orders.AddAsync(order);

            await context.SaveChangesAsync();

            return order.Id;


        }
    }
}
