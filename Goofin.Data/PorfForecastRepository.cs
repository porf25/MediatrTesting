
using GoofinApi;
using GoofinApi.Context;

namespace TestApi.Data
{
    public class PorfForecastRepository : Repository<PorfForecast, PorfContext>
    {
        public PorfForecastRepository(PorfContext context) : base(context)
        {
        }
    }
}
