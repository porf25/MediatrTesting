
namespace GoofinApi.Handlers.Queries
{
    public class GetAllForecastHandler : IRequestHandler<GetAllForecastQuery, List<PorfForecast>>
    {
        private PorfContext _context;
        public GetAllForecastHandler(PorfContext context)
        {
            _context = context;
        }

        public async Task<List<PorfForecast>> Handle(GetAllForecastQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await _context.PorfForecasts.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return forecasts;
        }
    }
}
