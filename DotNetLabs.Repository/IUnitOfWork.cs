using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CommitChangesAsync();
    }

}