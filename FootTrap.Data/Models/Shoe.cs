﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Data.Models
{
    public class Shoe
    {

        public Shoe()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.OrderShoe = new HashSet<OrderShoe>();
        }


        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; } = null!;

        public Category Category { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [Precision(18,2)]
        public decimal Price { get; set; }

        public string? ShoeUrlImage { get; set; }

        public bool IsActive { get; set; }

        public ICollection<OrderShoe> OrderShoe { get; set; }
        public ICollection<SizeShoe> SizeShoe { get; set; }
    }
}
