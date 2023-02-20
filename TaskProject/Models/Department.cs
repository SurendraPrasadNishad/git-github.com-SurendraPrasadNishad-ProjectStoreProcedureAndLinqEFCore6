using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskProject.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        [Required]
        public string ? DepartmentName { get; set; }
       
        public List<Employee> ? Employees { get; set; }
    }
}
