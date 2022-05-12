using Carbon.Domain.EntityFrameworkCore;
using Carbon.Sample.API.Domain.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carbon.Sample.API.Infrastructure.Contexts.SampleContext.EntityConfigurations
{
	public class SampleEntityConfiguration : TenantManagedEntityConfigurationBase<SampleEntity>
	{

		public override void Configure(EntityTypeBuilder<SampleEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.TenantId)
				   .IsRequired(true);

			builder.Property(x => x.Name)
				   .IsRequired(true)
				   .HasMaxLength(512);

			// Configure relations etc.


			base.Configure(builder);
		}
	}

}
