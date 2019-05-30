namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyApp.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<MyApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateUsers(context);
        }

        public void CreateUsers(MyApp.Models.ApplicationDbContext context)
        {
            var new_user = new ApplicationUser { UserName = "test@gmail.com" };
            var user_manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            user_manager.Create(new_user, "pass@123");
            
        }
    }
}
