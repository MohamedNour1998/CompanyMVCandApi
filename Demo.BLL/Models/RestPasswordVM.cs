using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
   public class RestPasswordVM
    {

        [Required(ErrorMessage = "This filed Is Required")]
        [MinLength(6, ErrorMessage = "the password min length  6 ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This filed Is Required")]
        [MinLength(6, ErrorMessage = "min length  6 ")]
        [Compare("Password", ErrorMessage = "the password dont matching")]
        
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }

}
