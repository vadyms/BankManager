using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankManager.Models
{
    public class RegModel
    {
        [Required]
        [StringLength( 150 )]
        [Display( Name = "Login:" )]
        public string Login { get; set; }

        [Required]
        [DataType( DataType.Password )]
        [StringLength( 20, MinimumLength = 1 )]
        [Display( Name = "Password" )]
        public string Password { get; set; }

        [Required]
        [DataType( DataType.Password )]
        [StringLength( 20, MinimumLength = 1 )]
        [Display( Name = "Password" )]
        public string RepeatPassword { get; set; }

        [Required]
        [DataType( DataType.EmailAddress)]
        [Display( Name = "Email" )]
        public string Email { get; set; }

        [Display( Name = "Address" )]
        public string Address { get; set; }
    }
}