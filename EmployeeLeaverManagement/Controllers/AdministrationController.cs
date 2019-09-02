using EmployeeLeaverManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EmployeeLeaverManagement;
using System.Threading.Tasks;
namespace EmployeeLeaverManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        public ActionResult DashBoard()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            ViewBag.Name = user.Email;
            return View();
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //ModelState.AddModelError("", "error");
            return View(db.Departments.ToList());
        }
        // GET: Administration/Create
        public ActionResult Department()
        {
            return View();
        }

        //[NonAction]
        public JsonResult IsDepartmentExits(string DepartmentName)
        {
            bool ab = !db.Departments.Any(m => m.DepartmentName == DepartmentName);
            return Json(!db.Departments.Any(m => m.DepartmentName == DepartmentName), JsonRequestBehavior.AllowGet);
        }
        // POST: Administration/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Department([Bind(Include = "DepartmentID,DepartmentName")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit_Department(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Departments departments = db.Departments.Find(id);
            return View(departments);

        }

        [HttpPost]
        public ActionResult Edit_Department([Bind(Include = "DepartmentID,DepartmentName")] Departments departments, int? id)
        {
            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    var user = db.Departments.Find(id);
                    user.DepartmentName = departments.DepartmentName;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Department");
                }
            }
            return RedirectToAction("Department");

        }

        //GET: Administration/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Departments departments = db.Departments.Find(id);
        //    if (departments == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(departments);
        //}

        // POST: Administration/Delete/5
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [HttpGet]//, ActionName("Delete")
        // [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)//Confirmed
        {
            if (id != null)
            {
                Departments departments = db.Departments.Find(id);
                db.Departments.Remove(departments);
                db.SaveChanges();
                return RedirectToAction("Department");
            }
            return RedirectToAction("Department");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public JsonResult IsLeaveTypeExits(LeaveType TypeName)
        {
            bool ab = !db.LeaveTypes.Any(m => m.LeaveTypeName == TypeName.LeaveTypeName);
            return Json(!db.LeaveTypes.Any(m => m.LeaveTypeName == TypeName.LeaveTypeName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddType([Bind(Include = "LeaveTypeID,LeaveTypeName ")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                db.LeaveTypes.Add(leaveType);
                db.SaveChanges();
                return RedirectToAction("AddTypeList");
            }
            return RedirectToAction("AddTypeList");
        }

        public ActionResult EditType(int? id)
        {
            if (id != null)
            {
                var type = db.LeaveTypes.Find(id);
                return View(type);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditType([Bind(Include = "LeaveTypeID,LeaveTypeName ")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                if (leaveType.LeaveTypeID != null)
                {
                    var user = db.LeaveTypes.Find(leaveType.LeaveTypeID);
                    user.LeaveTypeName = leaveType.LeaveTypeName;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AddType");
                }
            }
            return RedirectToAction("AddType");
        }

        public ActionResult AddTypeList()
        {
            return View(db.LeaveTypes.ToList());
        }

        public ActionResult EditLeave()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteLeave(int? id)
        {
            if (id != null)
            {
                LeaveType leaveType = db.LeaveTypes.Find(id);
                db.LeaveTypes.Remove(leaveType);
                db.SaveChanges();
                return RedirectToAction("AddType");
            }
            return RedirectToAction("AddType");
        }

        //Delete LeaveType
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("DeleteLeave")]
        //public ActionResult DeleteLeaveConfirmed(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LeaveType leaveType = db.LeaveTypes.Find(id);
        //    db.LeaveTypes.Remove(leaveType);
        //    db.SaveChanges();
        //    return RedirectToAction("AddType");
        //}

        [HttpGet]
        public ActionResult LeaveRequest(SubmitLeave sl)
        {
            try
            {
                var query = from s in db.SubmitLeaves
                            join l in db.LeaveTypes on s.LeaveTypeID equals l.LeaveTypeID
                            where s.IsActive == false
                            select s;
                return View(query.ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public async Task<ActionResult> ApprovedRequest(int? id, UserAlert ua)
        {

            try
            {
                if (id != null)
                {
                    var data = db.SubmitLeaves.Single(x => x.ID == id);
                    data.IsActive = true;
                    ua.ApplicationUserID = data.ApplicationUserID;
                    var name = data.ApplicationUser.Name;
                    string Description = "Dear " + name + " your leave from " + data.GetFormDate.ToString() + " to date " + data.GetToDate.ToString() + " is approved.";
                    ua.Description = Description;
                    ua.IsActive = true;
                    db.UserAlerts.Add(ua);
                    db.SaveChanges();
                    var message = new IdentityMessage { Body = Description, Destination = data.ApplicationUser.Email, Subject = "Leave approved" };
                    //await EmailService.SendEmailAsync(message);
                    return RedirectToAction("LeaveRequest");
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }

        }

        [HttpGet]
        public async Task<ActionResult> DeleteRequest(int? id)
        {
            try
            {
                if (id != null)
                {
                    UserAlert ua = new UserAlert();
                    var data = db.SubmitLeaves.Single(x => x.ID == id);
                    db.SubmitLeaves.Remove(data);
                    db.SaveChanges();
                    data.IsActive = true;
                    ua.ApplicationUserID = data.ApplicationUserID;
                    var name = data.ApplicationUser.Name;
                    string Description = "Dear " + name + " your leave from " + data.GetFormDate.ToString() + " to date " + data.GetToDate.ToString() + " is rejected.Please contact to admin";
                    ua.Description = Description;
                    ua.IsActive = true;
                    db.UserAlerts.Add(ua);
                    db.SaveChanges();
                    var message = new IdentityMessage { Body = Description, Destination = data.ApplicationUser.Email, Subject = "Leave rejected" };
                    //await EmailService.SendEmailAsync(message);

                    return RedirectToAction("LeaveRequest");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public ActionResult RegistrationRequest()
        //{
        //    var data = db.Registrations.Where(m => m.IsActive == false).ToList();
        //    if (data == null)
        //    {
        //        ViewBag.Message = "No request found.";
        //        return View();
        //    }
        //    return View(data);
        //}

        //[HttpGet]
        //public ActionResult Approved(int? id)
        //{
        //    if (id != null)
        //    {
        //        var data = db.Registrations.Single(x => x.RegistartionID == id);
        //        data.IsActive = true;
        //        db.SaveChanges();
        //        SendEmail.Mail(data.Email.ToString(), "Registration confirmed", "Dear" + data.UserName.ToString() + "now you can login.");
        //        return RedirectToAction("Approved");
        //    }


        //    return View();
        //}


    }
}