using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Data.Models.Enums;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> CreateOrderAsync(OrderFormModel model, string customerId)
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
                    ShoeSize = (int)shoe.Size!,
                };

                orderShoes.Add(sho);
            }

            order.OrderShoe = orderShoes;

            await context.Orders.AddAsync(order);

            await context.SaveChangesAsync();

            return order.Id;


        }

        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await context.Orders
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.HasValue
                        ? $"{o.DeliveryTime.Value.ToShortTimeString()} {o.DeliveryTime.Value.ToShortDateString()}"
                        : string.Empty,
                    OrderTime = $"{o.OrderTime.ToShortTimeString()} {o.OrderTime.ToShortDateString()}",
                    Status = o.Status,
                    Shoes = o.OrderShoe.Select(d => new OrderedShoeInfo()
                    {
                        Name = d.Shoe.Name,
                        Size = d.ShoeSize
                    }).ToList(),
                    Price = o.Price,

                })
                .ToListAsync();

            return orders;
        }

        public async Task<List<OrderViewModel>> GetCustomerOrdersAsync(string cutomerId)
        {
            var orders = await context.Orders
                .Where(o => o.CustomerId == cutomerId)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.HasValue
                        ? $"{o.DeliveryTime.Value.ToShortTimeString()} {o.DeliveryTime.Value.ToShortDateString()}"
                        : string.Empty,
                    OrderTime = $"{o.OrderTime.ToShortTimeString()} {o.OrderTime.ToShortDateString()}",
                    Status = o.Status,
                    Shoes = o.OrderShoe.Select(d => new OrderedShoeInfo()
                    {
                        Name = d.Shoe.Name,
                        Size = d.ShoeSize
                    }).ToList(),
                    Price = o.Price,

                })
                .ToListAsync();

            return orders;
        }
    }
}
