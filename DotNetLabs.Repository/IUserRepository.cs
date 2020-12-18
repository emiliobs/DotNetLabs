using DotNetLabs.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string id);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task CreateUserAsync(ApplicationUser applicationUser, string role, string password);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<string> GetUserRoleAsync(ApplicationUser user);
    }
}
