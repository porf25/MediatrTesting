using AutoMapper;
using GoofinApi.Dtos;
using GoofinApi.Mappings;
using GoofinApi.Models;
using GoofinApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GoofinApi.Repositories
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserAuthenticationRepository(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var results = await _userManager.CreateAsync(user, userForRegistration.Password);
            return results;
        }
    }
}
