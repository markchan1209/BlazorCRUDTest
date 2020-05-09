using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Entity
{
    public class Employees
    {
        [Key]
        [Display(Name = "編號")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "國家")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "性別")]
        public int Gender { get; set; }
    }
}
