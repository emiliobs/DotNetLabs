using DotNetLabs.Blazor.Shared;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Services
{
    public interface IUserService
    {
        Task<OperationResponse<string>> RegisterUserAsync(RegisterRequest model);

        Task<LoginResponse> GenerateTokenAsync(LoginRequest loginRequest);
    }
}
