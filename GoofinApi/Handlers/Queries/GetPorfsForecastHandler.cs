

namespace GoofinApi.Handlers.Queries
{
    public class GetPorfsForecastHandler : IRequestHandler<GetPorfsForecastQuery, PorfForecast>
    {
        private readonly ITestRepo _testRepo;
        private readonly PorfContext _context;
        public GetPorfsForecastHandler(ITestRepo testRepo, PorfContext context)
        {
            _testRepo = testRepo;
            _context = context;
        }

        public async Task<PorfForecast> Handle(GetPorfsForecastQuery request, CancellationToken cancellationToken)
        {
            var test = _testRepo.GetTestData("test name");
            var message = $"Hey man, its {request.Name}.. dale";
            var forcast = await _context.PorfForecasts.AsNoTracking().FirstOrDefaultAsync(x => x.Message == message, cancellationToken: cancellationToken);
            return forcast ?? new PorfForecast();
        }
    }
}
