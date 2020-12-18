using DotNetLabs.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Services
{
    public interface IUserService
    {
        //Task RegisterUserAsync();

        Task<object> GenerateTokenAsync(LoginRequest loginRequest);
    }
}
