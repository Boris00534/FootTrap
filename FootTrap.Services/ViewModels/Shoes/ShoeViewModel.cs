using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.ViewModels.Shoes
{
    public class ShoeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ShoePictureUrl { get; set; }

        public decimal Price { get; set; }

        public int Size { get; set; }

    }
}
