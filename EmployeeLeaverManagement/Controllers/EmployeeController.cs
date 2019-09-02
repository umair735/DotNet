using EmployeeLeaverManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace EmployeeLeaverManagement.Controllers
{

    public class EmployeeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Dashboard()
        {

            return View();
        }        

        public ActionResult Submit_Leave()
        {
            ViewBag.LeaveTypeList = new SelectList(db.LeaveTypes, "LeaveTypeID", "LeaveTypeName");
            return View();
        }

        //[Bind(Include = "ID,GetLeaveTypeID,GetFormDate,GetToDate,GetApplicationText,GetIsApproved,GetIsDeny")]

        [HttpPost]
        public ActionResult Submit_Leave(SubmitLeave submitLeave)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                //var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
                submitLeave.ApplicationUserID = user;   
                submitLeave.IsActive = false;
                db.SubmitLeaves.Add(submitLeave);
                db.SaveChanges();
                ModelState.Clear();
                return View("Submit_Leave");                 
            }
            return View(submitLeave);            
        }

        //Employee Alerts
        public ActionResult EmployeeAlerts(UserAlert userAlert)
        {
            var id = User.Identity.GetUserId();
            var query = from u in db.UserAlerts
                        where u.IsActive == true && u.ApplicationUserID.Equals(id) 
                        select u;
            return View(query.ToList());
        }
    }
}