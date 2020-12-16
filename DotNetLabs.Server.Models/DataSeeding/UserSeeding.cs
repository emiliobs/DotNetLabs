using Microsoft.AspNetCore.Identity;

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


    }
}
