using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmployeeLeaverManagement.Models;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
namespace EmployeeLeaverManagement.Models
{
    public class SubmitLeave :IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name="Leave Type")]
        public int? LeaveTypeID { get; set; }
        public virtual LeaveType LeaveType { get; set; }

        [Required]
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime GetFormDate { get; set; }

        [Required]
        [Display(Name = "To Date")]
        [DataType(DataType.Date)]        
        public DateTime GetToDate { get; set; }        

        //public int? Days
        //{
        //    get { return (int)(GetFormDate - GetToDate).TotalDays; }
            
        //}
        

        [Required]
        [Display(Name = "Application Text")]
        //[RegularExpression( @"^([a-zA-Z\. <>&@\[\]\{\}0-9-_',\\\/#]*)$",ErrorMessage="invalid input")]
        public string GetApplicationText { get; set; }
        
        public bool GetIsApproved { get; set; }

        public bool GetIsDeny { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GetFormDate > GetToDate)
            {
                yield return
                  new ValidationResult(errorMessage: "From Date must be less than Todate");
            }            
        }
        
    }
}