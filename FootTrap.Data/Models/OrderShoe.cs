using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Data.Models
{
    public class OrderShoe
    {
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }

        public Order Order { get; set; }

        [ForeignKey(nameof(Shoe))]
        public string ShoeId { get; set; }

        public Shoe Shoe { get; set;}
    }
}
