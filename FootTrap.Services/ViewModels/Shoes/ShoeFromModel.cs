using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Services.ViewModels.Category;
using FootTrap.Services.ViewModels.Size;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static FootTrap.Common.ModelValidationConstants.ShoeConstants;

namespace FootTrap.Services.ViewModels.Shoes
{
    public class ShoeFromModel
    {
        public ShoeFromModel()
        {
            this.Sizes = new HashSet<SizeViewModel>();
            this.Categories = new HashSet<CategoryViewModel>();
        }
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }

        public IFormFile? ShoeUrlImage { get; set; }

        public int? SizeId { get; set; }

        public ICollection<SizeViewModel> Sizes { get; set; }

        public string? CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
