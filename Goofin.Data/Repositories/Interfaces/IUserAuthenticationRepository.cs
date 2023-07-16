using GoofinApi.Dtos;
using GoofinApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GoofinApi.Repositories.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<bool> VerifyUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
    }
}
