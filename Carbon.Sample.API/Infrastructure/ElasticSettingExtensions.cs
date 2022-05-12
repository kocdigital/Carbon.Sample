using Carbon.ElasticSearch.Abstractions;
using Carbon.Sample.API.Domain.Entities;

using System.Collections.Generic;

namespace Carbon.Sample.API.Infrastructure
{
	public static class ElasticSettingExtensions
	{

		public static void SetElasticConfiguration(this IElasticSettings options)
		{
			var mappings = new List<ElasticIndexMapping>();

			mappings.Add(new ElasticIndexMapping(nameof(SampleEntity).ToLower(), c =>
					c.Map<SampleEntity>(m =>
							m.AutoMap().Properties(ps => ps.Keyword(s => s.Name(n => n.Id)))
							.Properties(ps => ps.Keyword(s => s.Name(n => n.TenantId)))
					).Settings(x => x.Setting("mapping.total_fields.limit", "100000"))
			));

			options.SetIndexsAndAutoMappings(mappings.ToArray());
		}
	}
}
