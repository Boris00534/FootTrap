﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Services.ViewModels.Category;
using FootTrap.Services.ViewModels.Size;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FootTrap.Services.ViewModels.Shoes
{
    public class ShoeFormModel
    {
        public ShoeFormModel()
        {
            this.Sizes = new HashSet<SizeViewModel>();
            this.Categories = new HashSet<CategoryViewModel>();
            this.SizeIds = new List<int>();
        }

        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; } = null!;

        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Precision(18,2)]
        public string Price { get; set; }

        public IFormFile? ShoeUrlImage { get; set; }

        public List<int> SizeIds { get; set; }

        public ICollection<SizeViewModel> Sizes { get; set; }

        public string? CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
