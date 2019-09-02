using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeLeaverManagement.Models
{
    public class LeaveType
    {
        [Key]
        public int? LeaveTypeID { get; set; }
        
        [Display(Name = "LeaveType Name")]
        [Required(ErrorMessage = "Please enter LeaveType Name")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [RegularExpression(@"^([a-zA-Z\.\, ]+)$", ErrorMessage = "Invalid Input")]
        [Remote("IsLeaveTypeExits", "Administration", ErrorMessage = "Leave Name already exits")]
        public string LeaveTypeName { get; set; }
        
        public virtual ICollection<SubmitLeave> SubmitLeaves { get; set; }
    }
}