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
        private IPlayListRespository _playList;


        public EfUnitOfWork(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new IdentityUserRepository(_userManager, _roleManager);
                }

                return _users;
            }
        }



        public IPlayListRespository PlayList
        {
            get
            {
                if (_playList == null)
                {
                    _playList = new PLayListRepository(_db);
                }

                return _playList;
            }

        }


        public async Task CommitChangesAsync(string userId)
        {
            await _db.SaveChangesAsync(userId);
        }
    }
}
