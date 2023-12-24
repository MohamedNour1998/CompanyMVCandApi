using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
   public class ForgetPassswordVM
    {
        [EmailAddress(ErrorMessage = "InVaild Mail")]
        [Required(ErrorMessage = "This filed Is Required")]
        public string Email { get; set; }
    }
}
