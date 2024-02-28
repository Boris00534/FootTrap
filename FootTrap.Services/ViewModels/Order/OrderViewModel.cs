using FootTrap.Services.ViewModels.Shoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Shoes = new List<OrderShoeViewModel>();
        }
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string City { get; set; } = null!;

        public ICollection<OrderShoeViewModel> Shoes { get; set; }
    }
}
