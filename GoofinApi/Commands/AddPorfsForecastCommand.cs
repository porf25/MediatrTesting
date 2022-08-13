

namespace GoofinApi.Commands
{
    public class AddPorfsForecastCommand : IRequest<PorfForecast>
    {
        public string? Name { get; set; }
    }
}
