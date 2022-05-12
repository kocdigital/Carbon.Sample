using Carbon.TimeSeriesDb.Abstractions.Entities;
using Carbon.TimeSeriesDb.Abstractions.Repositories;

using System;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Repositories.Abstract
{
	public interface IDataRepository<TEntity> : ITimeSeriesEntityRepository<TEntity>
		where TEntity : class, ITimeSeriesEntity
	{
		public Task<TEntity> GetLatestDataByAssetAndTelemetryId(Guid assetId, Guid telemetryId, Guid tenantId);
	}
}
