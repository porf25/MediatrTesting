

using Microsoft.AspNetCore.Authorization;

namespace GoofinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetPorfsForecast/GetForecastByName/{name}")]
        public async Task<IActionResult> GetPorfCast([FromRoute] string name)
        {
            var result = await _mediator.Send(new GetPorfsForecastQuery
            {
                Name = name,
            });

            return Ok(result);            
        }

        [HttpGet]
        [Route("GetPorfsForecast")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllForecastQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("AddPorfsForecast/{name}")]
        public async Task<IActionResult> AddtPorfCast([FromRoute] string name)
        {
            var result = await _mediator.Send(new AddPorfsForecastCommand
            {
                Name = name,
            });

            return Ok(result);
        }

    }
}