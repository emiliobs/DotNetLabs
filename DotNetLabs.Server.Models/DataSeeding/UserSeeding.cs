using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Models.DataSeeding
{
    public class UserSeeding
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserSeeding(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task SeedData()
        {
            if (await _roleManager.FindByNameAsync("Admin") != null) return;

            //Crate Roles:
            //var adminRole = new IdentityRole { Name = "Admin" };
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

            //var userRole = new IdentityRole { Name = "User" };
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });

            //Create Users
            var admin = new ApplicationUser
            {
                Email = "barrera_emilio@hotmail.com",
                UserName = "barrera_emilio@hotmail.com",
                FirstName = "Emilio",
                LastName = "Barrera"
            };

            //var user = new ApplicationUser
            //{
            //    Email = "barrera_emilio@yahoo.es",
            //    UserName = "barrera_emilio@yahoo.es",
            //    FirstName = "Emilio",
            //    LastName = "Barrera"
            //};

            await _userManager.CreateAsync(admin, "Emilio123.");
            await _userManager.AddToRoleAsync(admin, "Admin");
            //await _userManager.CreateAsync(user, "Emilio123.");
            //await _userManager.AddToRoleAsync(user, "User");

        }

    }
}
