using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Services.Abstract;
using Carbon.WebApplication;
using Carbon.WebApplication.HttpAtrributes;

using HybridModelBinding;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Application.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class DataController : CarbonController
	{
		private readonly IDataService _dataService;

		public DataController(IDataService dataService)
		{
			_dataService = dataService;
		}

		/// <summary>
		/// Temporary Action to test and valid the business
		/// </summary>
		/// <param name="tenantId">Carbon sets tenantId from Authorization header automatically</param>
		/// <param name="getLatestDataDto"></param>
		/// <returns></returns>
		[HttpGetCarbon]
		[Route("{assetId:Guid}/telemetry/{telemetryId:Guid}")]
		public async Task<IActionResult> GetLatestData([FromHybrid] GetLatestDataDto getLatestDataDto, [FromHeader] Guid tenantId)
		{
			var result = await _dataService.GetLatestDataByAssetAndTelemetryId(getLatestDataDto.AssetId, getLatestDataDto.TelemetryId, tenantId);

			return ResponseOk(result);
		}

		/// <summary>
		/// ModelContainer calls this method to send a desired telemetry value
		/// </summary>
		/// <param name="desiredDataDto"></param>
		/// <returns></returns>
		[HttpPostCarbon]
		[Route("SendDesiredTelemetryDataToP360")]
		public async Task<IActionResult> SendDesiredTelemetryDataToP360([FromHybrid] DesiredDataDto desiredDataDto)
		{
			var resp = await _dataService.SetDesiredTelemetryValueOnDataLog(desiredDataDto.AssetId, desiredDataDto.TelemetryId, desiredDataDto.Value);
			return ResponseOk(resp);
		}

	}
}
