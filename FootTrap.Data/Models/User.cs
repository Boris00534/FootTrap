using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.IsActive = true;
        }

        [MaxLength(30)]
        public string FirstName { get; set; } = null!;


        [MaxLength(30)]
        public string LastName { get; set; } = null!;

        [MaxLength(200)]
        public string City { get; set; } = null!;

        [MaxLength(100)]
        public string Country { get; set; } = null!;

        [MaxLength(200)]
        public string Address { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }


    }
}
