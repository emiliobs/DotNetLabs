using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }

        Task CommitChangesAsync();
    }

}