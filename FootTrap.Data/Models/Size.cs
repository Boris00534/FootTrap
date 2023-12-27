using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Data.Models
{
    public class Size
    {
        public Size()
        {
            this.Shoes = new HashSet<Shoe>();
        }
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public ICollection<Shoe> Shoes { get; set; }
    }
}
