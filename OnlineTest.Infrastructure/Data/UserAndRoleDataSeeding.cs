using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OnlineTest.Infrastructure.Data.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Infrastructure.Data
{

    public  class UserAndRoleDataSeeding
    {
        public static void SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {
                SeedRoles(roleManager);
                SeedUsers(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<UserAndRoleDataSeeding>();
                logger.LogError(ex.Message);
            }
        }

        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("User@App.com").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "User@App.com";
                user.Email = "User@App.com";
                user.FirstName = "User";
                user.LastName = "App";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, "12345@Mm").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }


            if (userManager.FindByEmailAsync("Admin@App.com").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "Admin@App.com";
                user.Email = "Admin@App.com";
                user.FirstName = "Admin";
                user.LastName = "App";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, "12345@Mm").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                AppRole role = new AppRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }


}
