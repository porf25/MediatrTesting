

using GoofinApi.Dtos;
using GoofinApi.Repositories.Interfaces;

namespace GoofinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserAuthenticationRepository _repo;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator, IUserAuthenticationRepository repo)
        {
            _logger = logger;
            _mediator = mediator;
            _repo = repo;
        }

        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {

            var userResult = await _repo.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            return !await _repo.VerifyUserAsync(user)
                ? Unauthorized()
                : Ok(new { Token = await _repo.CreateTokenAsync() });
        }

    }
}