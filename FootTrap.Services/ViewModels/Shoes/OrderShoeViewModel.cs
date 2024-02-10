using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.ViewModels.Shoes
{
    public class OrderShoeViewModel
    {
        public string Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string ShoeImageUrl { get; set; } = null!;

    }
}
