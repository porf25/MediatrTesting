using GoofinApi.Dtos;
using GoofinApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GoofinApi.Repositories.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
    }
}
