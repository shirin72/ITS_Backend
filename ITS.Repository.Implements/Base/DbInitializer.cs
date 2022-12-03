using ITS.Repository.Implements.Context;
using ITS.Repository.Implements.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Repository.Implements.Base
{
    public class DbInitializer
    {
        public static async Task EnsureDatabaseSeeded(RepositoryContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole();
                role.Id = "1";
                role.Name = "Admin";
                role.NormalizedName = "Admin";
                await roleManager.CreateAsync(role);
                await context.SaveChangesAsync();
            }
            if (!await roleManager.RoleExistsAsync("manager"))
            {
                var role = new IdentityRole();
                role.Id = "2";
                role.Name = "manager";
                role.NormalizedName = "manager";
                await roleManager.CreateAsync(role);
                await context.SaveChangesAsync();
            }
            if (!await roleManager.RoleExistsAsync("Guest"))
            {
                var role = new IdentityRole();
                role.Id = "3";
                role.Name = "Guest";
                role.NormalizedName = "Guest";
                await roleManager.CreateAsync(role);
                await context.SaveChangesAsync();
            }
            

            if (!context.Users.Any(u => u.UserName == "Oladhamzeh@live.com"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    FullName = "Mohammd Oladhamzeh",
                    UserName = "Oladhamzeh@live.com",
                    Email = "Oladhamzeh@live.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Aa@123456");
                if (result.Succeeded)
                {
                    var approle = roleManager.FindByIdAsync("1");
                    if (approle != null)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }

        }

    }
}
