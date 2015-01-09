using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankManager.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(150)]
        [Display( Name = "Login:" )]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        //[StringLength(20,MinimumLength=1)]
        [Display(Name="Password")]
        public string Password { get; set; }
        
        [Required]
        public bool RememberMe { get; set; }
    }
}