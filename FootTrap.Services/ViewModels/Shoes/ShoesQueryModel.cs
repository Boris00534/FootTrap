using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Services.ViewModels.Shoes
{
    public class ShoesQueryModel
    {
        public ShoesQueryModel()
        {
            this.Shoes = new HashSet<ShoeViewModel>();
            this.Categories = new HashSet<string>();
            this.CurrentPage = 1;
            this.ShoesPerPage = 6;
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Dishes Per Page")]
        public int ShoesPerPage { get; set; }

        public int TotalShoes { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ShoeViewModel> Shoes { get; set; }
    }
}
