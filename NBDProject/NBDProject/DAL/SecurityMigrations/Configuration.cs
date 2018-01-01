namespace NBDProject.DAL.SecurityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NBDProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NBDProject.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\SecurityMigrations";
        }

        protected override void Seed(NBDProject.DAL.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new
                                       RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Admin"));

            }
            if (!context.Roles.Any(r => r.Name == "Admin Assistant"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Admin Assistant"));

            }
            if (!context.Roles.Any(r => r.Name == "Designer"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Designer"));

            }
            if (!context.Roles.Any(r => r.Name == "Chief Designer"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Chief Designer"));

            }

            if (!context.Roles.Any(r => r.Name == "Production Manager"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Production Manager"));

            }
            if (!context.Roles.Any(r => r.Name == "Group Manager"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Group Manager"));

            }
            if (!context.Roles.Any(r => r.Name == "Production Worker"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Production Worker"));

            }
            if (!context.Roles.Any(r => r.Name == "Sales"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Sales"));

            }
            
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var adminuser = new ApplicationUser
            {
                UserName = "admin1@outlook.com",
                // FavoriteIceCream = "Chocolate",
                Email = "admin1@outlook.com"
            };
            var adminAssistantuser = new ApplicationUser
            {
                UserName = "adminAssistant1@outlook.com",
                // FavoriteIceCream = "Chocolate",
                Email = "adminAssistant1@outlook.com"
            };

            var productionManageruser = new ApplicationUser
            {
                UserName = "productionManager1@outlook.com",
                // FavoriteIceCream = "Chocolate",
                Email = "productionManager1@outlook.com"
            };
            var groupmanageruser = new ApplicationUser
            {
                UserName = "groupManager1@outlook.com",
                Email = "groupManager1@outlook.com"
            };

            var productionworkeruser = new ApplicationUser
            {
                UserName = "productionWorker1@outlook.com",
                Email = "productionWorker1@outlook.com"
            };
            var designeruser = new ApplicationUser
            {
                UserName = "designer1@outlook.com",
                // FavoriteIceCream = "Chocolate",
                Email = "designer1@outlook.com"
            };
            var chiefdesigneruser = new ApplicationUser
            {
                UserName = "chiefDesigner1@outlook.com",
                Email = "chiefDesigner1@outlook.com"
            };

            var salesuser = new ApplicationUser
            {
                UserName = "sales1@outlook.com",
                // FavoriteIceCream = "Chocolate",
                Email = "sales1@outlook.com"
            };

            if (!context.Users.Any(u => u.UserName == "admin1@outlook.com"))
            {
                manager.Create(adminuser, "password");
                manager.AddToRole(adminuser.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "adminAssistant1@outlook.com"))
            {
                manager.Create(adminAssistantuser, "password");
                manager.AddToRole(adminAssistantuser.Id, "Admin Assistant");
            }
            if (!context.Users.Any(u => u.UserName == "designer1@outlook.com"))
            {
                manager.Create(designeruser, "password");
                manager.AddToRole(designeruser.Id, "Designer");
            }
            if (!context.Users.Any(u => u.UserName == "sales1@outlook.com"))
            {
                manager.Create(salesuser, "password");
                manager.AddToRole(salesuser.Id, "Sales");
            }
            if (!context.Users.Any(u => u.UserName == "productionManager1@outlook.com"))
            {
                manager.Create(productionManageruser, "password");
                manager.AddToRole(productionManageruser.Id, "Production Manager");
            }
            if (!context.Users.Any(u => u.UserName == "groupManager1@outlook.com"))
            {
                manager.Create(groupmanageruser, "password");
                manager.AddToRole(groupmanageruser.Id, "Group Manager");
            }
            if (!context.Users.Any(u => u.UserName == "productionWorker1@outlook.com"))
            {
                manager.Create(productionworkeruser, "password");
                manager.AddToRole(productionworkeruser.Id, "Production Worker");
            }
            if (!context.Users.Any(u => u.UserName == "chiefDesigner1@outlook.com"))
            {
                manager.Create(chiefdesigneruser, "password");
                manager.AddToRole(chiefdesigneruser.Id, "Chief Designer");
            }


        }
    }
}
