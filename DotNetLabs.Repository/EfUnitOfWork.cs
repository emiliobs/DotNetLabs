using DotNetLabs.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private IUserRepository _users;

        public EfUnitOfWork(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._db = db;
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new IdentityUserRepository(_userManager, _roleManager);

                return _users;
            }
        }

        public async Task CommitChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
