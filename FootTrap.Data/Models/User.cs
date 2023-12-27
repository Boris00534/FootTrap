using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FootTrap.Common.ModelValidationConstants.UserConstants;

namespace FootTrap.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.IsActive = true;
            this.Orders = new HashSet<Order>();
            this.Payments = new HashSet<Payment>();
        }

        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }


        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [MaxLength(CountryMaxLength)]
        public string Country { get; set; }

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
