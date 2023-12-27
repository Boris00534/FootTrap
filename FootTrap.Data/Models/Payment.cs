using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FootTrap.Common.ModelValidationConstants.PaymentConstants;

namespace FootTrap.Data.Models
{
    public class Payment
    {
        public Payment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey(nameof(Order))]
        public string? OrderId { get; set; }
        
        public Order? Order { get; set; }

        [MaxLength(CardNumberMaxLength)]
        public string CardNumber { get; set; }

        [MaxLength(CardHolderMaxLength)]
        public string CardHolder { get; set; }

        public DateTime ExpityDate { get; set; }

        [MaxLength(CardHolderMaxLength)]
        public string SecurityCode { get; set; }
    }
}
