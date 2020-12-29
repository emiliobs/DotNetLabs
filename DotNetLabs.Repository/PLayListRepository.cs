using DotNetLabs.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public class PLayListRepository : IPlayListRespository
    {
        private readonly ApplicationDbContext _dbContext;

        public PLayListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePlayListAsync(PlayList playList)
        {
            await _dbContext.playLists.AddAsync(playList);
        }

        public IEnumerable<PlayList> GetAllPlayList()
        {
            return _dbContext.playLists.ToList();
        }

        public async Task<PlayList> GetPLayListByIdAsync(string id)
        {
            return await _dbContext.playLists.FindAsync(id);
        }

        public void RemovePlayList(PlayList playList)
        {
            _dbContext.playLists.Remove(playList);
        }
    }
}
