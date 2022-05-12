using Carbon.Sample.API.Domain.Entities;
using Carbon.TimeScaleDb.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace Carbon.Sample.API.Infrastructure.Contexts.TimeSeriesContexts
{
	public class TimeSerieDataLogContext : CarbonTimeScaleDbContext<TimeSerieDataLogContext>
	{
		public TimeSerieDataLogContext(DbContextOptions<TimeSerieDataLogContext> options) : base(options)
		{

		}
		public DbSet<TimeSerieDataLog> TimeSerieDataLog { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}

}
