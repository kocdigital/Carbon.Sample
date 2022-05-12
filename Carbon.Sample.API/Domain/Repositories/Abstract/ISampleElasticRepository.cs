using Carbon.ElasticSearch.Abstractions;
using Carbon.Sample.API.Domain.Entities;

namespace Carbon.Sample.API.Domain.Repositories.Abstract
{
	public interface ISampleElasticRepository : IElasticRepository<SampleEntity>
	{
	}
}
