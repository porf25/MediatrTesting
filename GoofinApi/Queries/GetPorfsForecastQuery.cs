

namespace GoofinApi.Queries
{
    public class GetPorfsForecastQuery : IRequest<PorfForecast>
    {
        public string? Name { get; set; }
    }
}
