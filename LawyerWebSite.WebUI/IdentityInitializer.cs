using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeddData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole(){ Name = "Admin"});
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole() {Name="Member"});
            }

            var user = await userManager.FindByNameAsync("admin");
            if (user == null)
            {
                var adminUser = new AppUser()
                {
                    FirstName = "deneme",
                    LastName = "deneme",
                    UserName = "admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                await userManager.CreateAsync(adminUser, "Admin.123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
