using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Infrastructure.Contexts.TimeSeriesContexts;
using Carbon.TimeScaleDb.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Repositories
{
	public class DataRepository : EFTimeScaleDbWithReadOnlyRepository<TimeSerieDataLog, TimeSerieDataLogContext, TimeSerieDataLogReadOnlyContext>, IDataRepository<TimeSerieDataLog>
	{
		private readonly TimeSerieDataLogContext _timeSerieDataLogContext;
		private readonly TimeSerieDataLogReadOnlyContext _timeSerieDataLogReadOnlyContext;

		public DataRepository(TimeSerieDataLogContext context, TimeSerieDataLogReadOnlyContext rContext) : base(context, rContext)
		{
			_timeSerieDataLogContext = context;
			_timeSerieDataLogReadOnlyContext = rContext;
		}

		public async Task<TimeSerieDataLog> GetLatestDataByAssetAndTelemetryId(Guid assetId, Guid telemetryId, Guid tenantId)
		{
			return await _timeSerieDataLogReadOnlyContext.Set<TimeSerieDataLog>().Where(k => k.AssetId == assetId && k.TelemetryId == telemetryId && k.TenantId == tenantId).OrderByDescending(k => k.Date).FirstOrDefaultAsync();
		}
	}
}
