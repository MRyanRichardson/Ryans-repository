namespace GuildCarsUI.Migrations
{
    using GuildCarsUI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCarsUI.Models.GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCarsUI.Models.GuildCarsDbContext context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            if (!roleMgr.RoleExists("Admin"))
            {
                roleMgr.Create(new AppRole() { Name = "Admin" });
            }

            if (!roleMgr.RoleExists("Sales"))
            {
                roleMgr.Create(new AppRole() { Name = "Sales" });
            }

            if (!roleMgr.RoleExists("Disabled"))
            {
                roleMgr.Create(new AppRole() { Name = "Disabled" });
            }

            var user = new AppUser()
            {
                UserName = "Ryan",
                Email = "richardsonryan40@gmail.com",
                FirstName = "Ryan",
                LastName = "Richardson"
            };

            userMgr.Create(user, "BigHunting1");

            userMgr.AddToRole(user.Id, "Admin");
        }
    }
}
