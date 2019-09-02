using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeLeaverManagement.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }

        [Display(Name="Department Name")]
        [Required(ErrorMessage="Please enter Department Name")]
        [StringLength(25,ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [RegularExpression(@"^([a-zA-Z\.\, ]+)$", ErrorMessage = "Invalid Input")]
        [Remote("IsDepartmentExits", "Administration", ErrorMessage = "Department Name already exits")]
        public string DepartmentName { get; set; }

        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }


    }
}