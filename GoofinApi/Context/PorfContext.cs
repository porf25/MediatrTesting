

namespace GoofinApi.Context
{
    public class PorfContext : DbContext
    {
        public PorfContext(DbContextOptions<PorfContext> options) : base(options) { }

        public DbSet<PorfForecast> PorfForecasts { get; set; }
    }
}
