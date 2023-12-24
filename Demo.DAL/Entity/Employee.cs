using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {

       
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public int DepartmentId { get; set; }
        // [ForeignKey("DepartmentId")]
        public Department Department { get; set; }//navigation prop for [foregin key]

        public int DistrictId { get; set; }
        
        public District District { get; set; }


        public string PhotoName { get; set; }
        public string CvName { get; set; }
    }

}
