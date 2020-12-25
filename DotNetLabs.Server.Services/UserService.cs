using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Infrastructure;
using DotNetLabs.Server.Models;
using DotNetLabs.Server.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthOptions _authOptions;

        public UserService(IUnitOfWork unitOfWork, AuthOptions authOptions)
        {
            _unitOfWork = unitOfWork;
            _authOptions = authOptions;
        }

        public async Task<LoginResponse> GenerateTokenAsync(LoginRequest loginRequest)
        {
            Models.ApplicationUser user = await _unitOfWork.Users.GetUserByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return new LoginResponse
                {
                    Message = "Invalid Username or Password",
                    IsSuccess = false,
                };
            }

            if (!(await _unitOfWork.Users.CheckPasswordAsync(user, loginRequest.Password)))
            {
                return new LoginResponse
                {
                    Message = "Invalid Username or Passwrod",
                    IsSuccess = false,
                };
            }

            string userRole = await _unitOfWork.Users.GetUserRoleAsync(user);

            Claim[] claims = new Claim[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id),
               new Claim(ClaimTypes.GivenName, user.FirstName),
               new Claim(ClaimTypes.Surname, user.LastName),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Role, userRole),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Key));
            DateTime expireDate = DateTime.Now.AddDays(30);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: claims,
                expires: expireDate,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponse
            {
                Message = "Welcome to DotNet Lab.",
                IsSuccess = true,
                AccessToken = tokenAsString,
                ExpireDate = expireDate,
            };

        }

        public async Task<OperationResponse<string>> RegisterUserAsync(RegisterRequest model)
        {
            var userByEmail = await _unitOfWork.Users.GetUserByEmailAsync(model.Email);

            if (userByEmail != null)
            {
                return new OperationResponse<string>
                {
                    IsSuccess = false,
                    Message = "User is already Exist",
                };
            }

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            await _unitOfWork.Users.CreateUserAsync(user, model.Password, "User");

            return new OperationResponse<string>
            {
                Message = "Welcome to DotNet Labs, You were Added",
                IsSuccess = true,
            };
        }
    }
}
