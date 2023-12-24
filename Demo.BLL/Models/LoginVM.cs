using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
   public class LoginVM
    {

        [EmailAddress(ErrorMessage = "InVaild Mail")]
        [Required(ErrorMessage = "This filed Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This filed Is Required")]
        [MinLength(6, ErrorMessage = "the password min length  6 ")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
