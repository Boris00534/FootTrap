using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.Extensions;
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

                })
                .ToListAsync();


            return new AllShoesFilteredAndPaged()
            {
                Shoes = shoeModel,
                TotalShoes = shoeModel.Count()
            };
        }

        public async Task<string> AddAsync(ShoeFromModel model)
        {
            var shoe = new Shoe()
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price, 
                
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
                .FirstOrDefaultAsync(sh => sh.Id == shoeId);

            return shoe;
              

        }

        public async Task<bool> IsExistsAsync(string id)
        {
            return await context.Shoes.AnyAsync(sho => sho.Id == id);
        }

        public List<OrderShoeViewModel> GetCartShoes(string username)
        {
            return accessor.HttpContext.Session.GetObjectFromJson<List<OrderShoeViewModel>>($"cart{username}");
        }

        public Task AddShoeToCart(string username, string shoeId)
        {
            throw new NotImplementedException();
        }
    }
}
