using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Shoes;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class ShoeService : IShoeService
    {
        private readonly FootTrapDbContext context;
        private readonly IImageService imageService;

        public ShoeService(FootTrapDbContext context, IImageService imageService)
        {
            this.context = context;
            this.imageService = imageService;
        }
        public async Task<AllShoesFilteredAndPaged> GetAllShoesFilteredAndPagedAsync(ShoesQueryModel model)
        {
            IQueryable<Shoe> shoesQuery = context.Shoes
                .Include(s => s.Category)
                .Include(s => s.Size)
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
                    Size = s.Size.Number

                })
                .ToListAsync();


            return new AllShoesFilteredAndPaged()
            {
                Shoes = shoeModel,
                TotalShoes = shoeModel.Count()
            };
        }

        public async Task AddAsync(ShoeFromModel model)
        {
            var shoe = new Shoe()
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
                SizeId = (int)model.SizeId!,
                Price = model.Price, 
                
            };

            if (model.ShoeUrlImage != null)
            {
                shoe.ShoeUrlImage = await imageService.UploadImageToShoe(model.ShoeUrlImage!, "FootTrapProject", shoe);
            }

            await context.Shoes.AddAsync(shoe);
            await context.SaveChangesAsync();
        }
    }
}
