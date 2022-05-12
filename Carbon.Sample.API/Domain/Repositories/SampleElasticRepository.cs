using Carbon.ElasticSearch;
using Carbon.ElasticSearch.Abstractions;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;

namespace Carbon.Sample.API.Domain.Repositories
{
	public class SampleElasticRepository : BaseElasticRepository<SampleEntity>, ISampleElasticRepository
	{
		private readonly string _indexName;
		public SampleElasticRepository(IElasticSettings elasticSettings) : base(elasticSettings)
		{
			_indexName = nameof(SampleEntity).ToLower();
		}

		public override string Index => _indexName;
	}
}
