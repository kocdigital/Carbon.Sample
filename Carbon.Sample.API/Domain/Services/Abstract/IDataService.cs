using Carbon.Sample.API.Application.Dto;

using System;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Services.Abstract
{
	public interface IDataService
	{
		Task<LatestDataDto> GetLatestDataByAssetAndTelemetryId(Guid assetId, Guid telemetryId, Guid tenantId);
		Task<bool> SetDesiredTelemetryValueOnDataLog(Guid assetId, Guid telemetryId, string value);
	}
}
