using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EmployeeLeaverManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int DepartmentID { get; set; }
        //public virtual Departments Departments { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public bool IsAdminApproved { get; set; }

        public string ImaegeName { get; set; }

        public virtual ICollection<UserAlert> UserAlerts { get; set; }

        public virtual ICollection<SubmitLeave> SubmitLeaves { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EmployeeLeaverManagement.Models.Departments> Departments { get; set; }

        public System.Data.Entity.DbSet<EmployeeLeaverManagement.Models.LeaveType> LeaveTypes { get; set; }

        public System.Data.Entity.DbSet<EmployeeLeaverManagement.Models.SubmitLeave> SubmitLeaves { get; set; }

        public System.Data.Entity.DbSet<EmployeeLeaverManagement.Models.UserAlert> UserAlerts { get; set; }


        
    }
}