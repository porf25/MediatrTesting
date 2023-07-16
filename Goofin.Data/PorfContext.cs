

using GoofinApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoofinApi.Context
{
    public class PorfContext : IdentityDbContext<User>
    {
        public PorfContext(DbContextOptions<PorfContext> options) : base(options) { }

        public DbSet<PorfForecast> PorfForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
