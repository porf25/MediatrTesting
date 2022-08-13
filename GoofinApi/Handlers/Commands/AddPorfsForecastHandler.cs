

namespace GoofinApi.Handlers
{
    public class AddPorfsForecastHandler : IRequestHandler<AddPorfsForecastCommand, PorfForecast>
    {
        private readonly ITestRepo _testRepo;
        private PorfContext _context;
        public AddPorfsForecastHandler(ITestRepo testRepo, PorfContext context)
        {
            _testRepo = testRepo;
            _context = context;
        }

        public async Task<PorfForecast> Handle(AddPorfsForecastCommand request, CancellationToken cancellationToken)
        {
            var test = _testRepo.GetTestData("test name");

            var cast = new PorfForecast
            {
                Id = Guid.NewGuid(),
                Message = $"Hey man, its {request.Name}.. dale"
            };

            await _context.PorfForecasts.AddAsync(cast, cancellationToken);
            return cast;
        }
    }
}
