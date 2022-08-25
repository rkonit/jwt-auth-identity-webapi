using JwtAuthWebApi.Models;
using JwtAuthWebApi.Utils;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthWebApi.Data;

public class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext identityDbContext, 
        UserManager<ApplicationUser> userManager, 
        RoleManager<IdentityRole> roleManager)
    {
        if (identityDbContext.Database.IsSqlServer())
        {
            identityDbContext.Database.Migrate();
        }

        // Add default roles
        await roleManager.CreateAsync(new IdentityRole(Constants.Roles.ADMINISTRATOR));
        await roleManager.CreateAsync(new IdentityRole(Constants.Roles.USER));

        // Add default administrator
        var defaultAdmin = new ApplicationUser
        {
            UserName = "demoadmin@microsoft.com",
            Email = "demoadmin@microsoft.com"
        };
        await userManager.CreateAsync(defaultAdmin, Constants.DEFAULT_PASSWORD);
        defaultAdmin = await userManager.FindByNameAsync("demoadmin@microsoft.com");
        await userManager.AddToRoleAsync(defaultAdmin, Constants.Roles.ADMINISTRATOR);

        // Add default user
        var defaultUser = new ApplicationUser 
        { 
            UserName = "demouser@microsoft.com",
            Email = "demouser@microsoft.com"
        };
        await userManager.CreateAsync(defaultUser, Constants.DEFAULT_PASSWORD);
    }
}
