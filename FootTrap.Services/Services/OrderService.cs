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

        public async Task AddDeliveryTimeForOrderAsync(AcceptOrderFormModel model)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == model.Id);
            if (order == null)
            {
                return;
            }

            order.DeliveryTime = model.DeliveryTime;
            await context.SaveChangesAsync();
        }

        public async Task ChangeStatusOrderAsync(string orderId, string status)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return;
            }

            order.Status = status;

            await context.SaveChangesAsync();
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

        public async Task EditDeliveryTimeForOrderAsync(AcceptOrderFormModel model)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == model.Id);

            if(order == null)
            {
                return;
            }

            order.DeliveryTime = model.DeliveryTime;

            await context.SaveChangesAsync();

        }

        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await context.Orders
                .Include(o => o.OrderShoe)
                .Include(o => o.Customer)
                .Include(o => o.Customer.User)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.HasValue
                        ? $"{o.DeliveryTime.Value.ToString("dddd, dd MMMM yyyy")}"
                        : string.Empty,
                    OrderTime = $"{o.OrderTime.ToString("dddd, dd MMMM yyyy")}",
                    Status = o.Status,
                    CustomerPhoneNumber = o.Customer.User.PhoneNumber,
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
                .Include(o => o.OrderShoe)
                .Include(o => o.Customer.User)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.HasValue
                        ?  o.DeliveryTime.Value.ToString("dddd, dd MMMM yyyy")
                        : string.Empty,
                    OrderTime = o.OrderTime.ToString("dddd, dd MMMM yyyy"),
                    Status = o.Status,
                    CustomerPhoneNumber = o.Customer.User.PhoneNumber,
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

        public async Task<AcceptOrderFormModel> GetOrderByIdAsync(string orderId)
        {
            var order = await context.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.OrderShoe)
                .Include(o => o.Customer.User)
                .Select(o => new AcceptOrderFormModel()
                {
                    Id = o.Id, 
                    CustomerName = $"{o.Customer.User.FirstName} {o.Customer.User.LastName}", 
                    OrderTime = o.OrderTime.ToString("dddd, dd MMMM yyyy"),
                    Status = o.Status,
                    DeliveryAddress = o.DeliveryAddress,
                    Shoes = o.OrderShoe.Select(s => new OrderedShoeInfo()
                    {
                        Name = s.Shoe.Name, 
                        Size = s.ShoeSize
                    })
                    .ToList(), 
                    Price = o.Price,

                })
                .FirstOrDefaultAsync();


            return order!;
        }

        public async Task<AcceptOrderFormModel> GetOrderForEditByIdAsync(string orderId)
        {
            var order = await context.Orders
               .Where(o => o.Id == orderId)
               .Include(o => o.OrderShoe)
               .Include(o => o.Customer.User)
               .Select(o => new AcceptOrderFormModel()
               {
                   Id = o.Id,
                   CustomerName = $"{o.Customer.User.FirstName} {o.Customer.User.LastName}",
                   OrderTime = o.OrderTime.ToString("dddd, dd MMMM yyyy"),
                   Status = o.Status,
                   DeliveryAddress = o.DeliveryAddress,
                   DeliveryTime = (DateTime)o.DeliveryTime,
                   Shoes = o.OrderShoe.Select(s => new OrderedShoeInfo()
                   {
                       Name = s.Shoe.Name,
                       Size = s.ShoeSize
                   })
                   .ToList(),
                   Price = o.Price,

               })
               .FirstOrDefaultAsync();
            


            return order!;
        }

        public async Task<bool> IsOrderExistsAsync(string orderId)
        {
            var isExists = await context.Orders
                .AnyAsync(o => o.Id == orderId);

            return isExists;
        }
    }
}
