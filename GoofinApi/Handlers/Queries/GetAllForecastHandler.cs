
namespace GoofinApi.Handlers.Queries
{
    public class GetAllForecastHandler : IRequestHandler<GetAllForecastQuery, List<PorfForecast>>
    {
        private PorfForecastRepository _repo;
        public GetAllForecastHandler(PorfForecastRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PorfForecast>> Handle(GetAllForecastQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await _repo.GetAll();
            return forecasts;
        }
    }
}
