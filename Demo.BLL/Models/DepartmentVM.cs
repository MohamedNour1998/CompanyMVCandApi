using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
  public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="the Name is reqired")]
        [StringLength(50,ErrorMessage ="max length 50 letter")]
        [MinLength(3,ErrorMessage ="the min length is 3 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the Code is reqired")]
        public int Code { get; set; }
    }
}
