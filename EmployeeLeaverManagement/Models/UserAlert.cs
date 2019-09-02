using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeLeaverManagement.Models
{
    public class UserAlert
    {
        [Key]
        public int UserAlertID { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}