using Carbon.Domain.Abstractions.Entities;
using Carbon.Domain.EntityFrameworkCore;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Infrastructure.Contexts.SampleContext.EntityConfigurations;

using Microsoft.EntityFrameworkCore;

namespace Carbon.Sample.API.Infrastructure.Contexts.SampleContext
{
	public class SampleDBContext : CarbonContext<SampleDBContext>
	{
		public SampleDBContext(DbContextOptions options) : base(options)
		{

		}

		public virtual DbSet<SampleEntity> SampleEntity { get; set; }
		public virtual DbSet<EntitySolutionRelation> EntitySolutionRelation { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseLazyLoadingProxies();
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new SampleEntityConfiguration());
			modelBuilder.ApplyConfiguration(new EntitySolutionRelationEntityConfiguration());
			base.OnModelCreating(modelBuilder);
		}

	}
}

