using FootTrap.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FootTrap.Common.ModelValidationConstants.OrderConstants;

namespace FootTrap.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderShoe = new HashSet<OrderShoe>();
            this.OrderTime = DateTime.Now;
           
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [EnumDataType(typeof(OrderStatusEnum))]
        public string Status { get; set; }

        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime? DeliveryTime { get; set; }

        [MaxLength(DeliveryAddressMaxLength)]
        public string DeliveryAddress { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Payment))]
        public string? PaymentId { get; set; }

        public Payment? Payment { get; set; }

        public ICollection<OrderShoe> OrderShoe { get; set; }

        

    }
}
