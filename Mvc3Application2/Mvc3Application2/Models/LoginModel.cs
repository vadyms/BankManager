using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Mvc3Application2.Controllers
{
    public class LoginModel
    {
        [Required]
        [StringLength(4)]
        public string Username { get; set; }
        [Required]
        [StringLength(4)]
        public string Password { get; set; }
    }
}
