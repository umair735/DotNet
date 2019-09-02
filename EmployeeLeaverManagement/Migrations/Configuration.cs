namespace EmployeeLeaverManagement.Migrations
{
    using EmployeeLeaverManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Owin;
    using System.Configuration;
    using System.Web;
    using Microsoft.AspNet.Identity.Owin;
    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeLeaverManagement.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeLeaverManagement.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            InitializeIdentityForEF();
            context.Departments.AddOrUpdate(m => m.DepartmentName,
            new Departments() { DepartmentName = "Math" });

            context.LeaveTypes.AddOrUpdate(m => m.LeaveTypeName,
            new LeaveType() { LeaveTypeName = "Sick Leave" });

            context.SaveChanges();

        }

        public static void InitializeIdentityForEF()
        {
            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            ApplicationDbContext context = new ApplicationDbContext();
            //var u = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            string name = ConfigurationManager.AppSettings["AdminmailAccount"];
            string password = ConfigurationManager.AppSettings["AdminmailPassword"];
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = UserManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                var result = UserManager.Create(user, password);
                result = UserManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = UserManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = UserManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
