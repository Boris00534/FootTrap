using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data;
using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Size;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.Services
{
    public class SizeService : ISizeService
    {
        private readonly FootTrapDbContext context;


        public SizeService(FootTrapDbContext context)
        {
            this.context = context;
        }
        public async Task<List<SizeViewModel>> GetAllSizesAsync()
        {
            var sizes = await context.Sizes
                .Select(s => new SizeViewModel()
                {
                    Id = s.Id, 
                    Number = s.Number
                })
                .ToListAsync();

            return sizes;
        }
    }
}
