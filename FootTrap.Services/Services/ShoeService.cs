using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Extensions;
using FootTrap.Services.ViewModels.Category;
using FootTrap.Services.ViewModels.Shoes;
using FootTrap.Services.ViewModels.Size;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class ShoeService : IShoeService
    {
        private readonly FootTrapDbContext context;
        private readonly IImageService imageService;
        private readonly IHttpContextAccessor accessor;

        public ShoeService(FootTrapDbContext context, IImageService imageService, IHttpContextAccessor accessor)
        {
            this.context = context;
            this.imageService = imageService;
            this.accessor = accessor;
        }
        public async Task<AllShoesFilteredAndPaged> GetAllShoesFilteredAndPagedAsync(ShoesQueryModel model)
        {
            IQueryable<Shoe> shoesQuery = context.Shoes
                .Include(s => s.Category)
                .Include(s => s.SizeShoe)
                .Where(s => s.IsActive);


            if (!string.IsNullOrEmpty(model.Category))
            {
                shoesQuery = shoesQuery.Where(sh => sh.Category.Name == model.Category);
            }

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                shoesQuery = shoesQuery
                    .Where(d => EF.Functions.Like(d.Name, wildCard) ||
                                EF.Functions.Like(d.Description, wildCard));

            }

            IEnumerable<ShoeViewModel> shoeModel = await shoesQuery
                .Where(d => d.IsActive)
                .Skip((model.CurrentPage - 1) * model.ShoesPerPage)
                .Take(model.ShoesPerPage)
                .Select(s => new ShoeViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    ShoePictureUrl = s.ShoeUrlImage,
                    Description = s.Description,

                })
                .ToListAsync();


            return new AllShoesFilteredAndPaged()
            {
                Shoes = shoeModel,
                TotalShoes = shoeModel.Count()
            };
        }

        public async Task<string> AddAsync(ShoeFormModel model)
        {
            var shoe = new Shoe()
            {
                CategoryId = model.CategoryId!,
                Name = model.Name,
                Description = model.Description,
                Price = Decimal.Parse(model.Price),

            };

            if (model.ShoeUrlImage != null)
            {
                shoe.ShoeUrlImage = await imageService.UploadImageToShoe(model.ShoeUrlImage!, "FootTrapProject", shoe);
            }

            await context.Shoes.AddAsync(shoe);
            await context.SaveChangesAsync();

            return shoe.Id;
        }

        public async Task<DetailsShoeViewModel> GetDetailsForShoeAsync(string shoeId)
        {
            var shoe = await context.Shoes
                .Include(sh => sh.Category)
                .Include(sh => sh.SizeShoe)
                .Where(sh => sh.Id == shoeId)
                .Select(sh => new DetailsShoeViewModel()
                {
                    Id = shoeId,
                    Name = sh.Name,
                    Description = sh.Description,
                    Price = sh.Price,
                    Category = sh.Category.Name,
                    Sizes = sh.SizeShoe.Select(s => new SizeViewModel()
                    {
                        Id = s.Size.Id,
                        Number = s.Size.Number
                    })
                    .ToList(),
                    ShoePictureUrl = sh.ShoeUrlImage

                })
                .FirstOrDefaultAsync();

            return shoe;


        }

        public async Task<bool> IsExistsAsync(string id)
        {
            return await context.Shoes.AnyAsync(sho => sho.Id == id);
        }

        public List<OrderShoeViewModel>? GetCartShoes(string username)
        {
            return accessor.HttpContext.Session.GetObjectFromJson<List<OrderShoeViewModel>>($"cart{username}");
        }

        public async Task AddShoeToCart(string username, string shoeId, int size)
        {
            if (accessor.HttpContext.Session.GetObjectFromJson<List<OrderShoeViewModel>>($"cart{username}") == null)
            {
                var shoe = await GetShoeForOrderAsync(shoeId, size);
                List<OrderShoeViewModel> cart = new List<OrderShoeViewModel>();
                cart.Add(shoe);
                accessor.HttpContext.Session.SetObjectAsJson($"cart{username}", cart);
            }
            else
            {
                List<OrderShoeViewModel>? cart = accessor.HttpContext.Session.GetObjectFromJson<List<OrderShoeViewModel>>($"cart{username}");
                var shoe = await this.GetShoeForOrderAsync(shoeId, size);
                cart!.Add(shoe);
                accessor.HttpContext.Session.SetObjectAsJson($"cart{username}", cart);
            }
        }

        public async Task<OrderShoeViewModel> GetShoeForOrderAsync(string shoeId, int size)
        {
            var shoe = await context.Shoes
                .Select(sho => new OrderShoeViewModel()
                {
                    Id = sho.Id,
                    Name = sho.Name,
                    Description = sho.Description,
                    Price = sho.Price,
                    Size = size,
                    ShoeImageUrl = sho.ShoeUrlImage,
                    IsEnabled = true,

                })
                .FirstOrDefaultAsync(sh => sh.Id == shoeId);

            return shoe!;

        }

        public async Task<ShoeFormModel> GetShoeForEditAsync(string shoeId)
        {
            var shoe = await context.Shoes
                 .Where(sh => sh.Id == shoeId)
                 .Select(sh => new ShoeFormModel()
                 {
                     Name = sh.Name,
                     Description = sh.Description,
                     Price = sh.Price.ToString(),

                 })
                 .FirstOrDefaultAsync();

            shoe!.Sizes = await context.Sizes
                .Select(s => new SizeViewModel()
                {
                    Id = s.Id,
                    Number = s.Number,
                })
                .ToListAsync();

            shoe.Categories = await context.Category
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id, 
                    Name = c.Name,
                })
                .ToListAsync();

            return shoe;
        }
    }
}
