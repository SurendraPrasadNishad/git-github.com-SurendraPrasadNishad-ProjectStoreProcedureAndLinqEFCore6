using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskProject.Models
{
    public class Employee
    {

        [Key]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        public string ? EmployeeName { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string ? EmployeeAddress { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public  Department ? Departments { get; set; }
    }
}
