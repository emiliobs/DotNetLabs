using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IPlayListRespository PlayList { get; }

        public IVideosRepository Videos { get;}

        Task CommitChangesAsync(string userId);
    }

}