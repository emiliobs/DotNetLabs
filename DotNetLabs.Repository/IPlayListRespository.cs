using DotNetLabs.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IPlayListRespository
    {
        IEnumerable<PlayList> GetAllPlayList();

        Task<PlayList> GetPLayListByIdAsync(string id);

        Task CreatePlayListAsync(PlayList playList);

        void RemovePlayList(PlayList playList);
    }


}
