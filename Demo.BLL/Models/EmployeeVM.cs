using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
   public class EmployeeVM
    {

        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "the Name is reqired")]
        [StringLength(50, ErrorMessage = "max length 50 letter")]
        [MinLength(3, ErrorMessage = "the min length is 3 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the Code is reqired")]
        [Range(3000,10000,ErrorMessage ="Range between 3000 :10000")]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }
        [EmailAddress(ErrorMessage ="Email invalid")]
        public string Email { get; set; }
        [RegularExpression("[0-9]{2,5}-[a-zA-z]{2,5}-[a-zA-z]{2,5}-[a-zA-z]{2,5}", ErrorMessage = "like 12-str-city-country")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "choose departmentId")]
        public int DepartmentId { get; set; }
        // [ForeignKey("DepartmentId")]
        public Department Department { get; set; }//navigation prop for [foregin key]

        public int DistrictId { get; set; }

        public District District { get; set; }

        public string PhotoName { get; set; }
        public string CvName { get; set; }

        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }
    }
}
