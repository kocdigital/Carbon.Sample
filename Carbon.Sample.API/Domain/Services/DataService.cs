using Carbon.HttpClient.Auth.IdentityServerSupport;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Domain.Services.Abstract;

using Mapster;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Services
{
	public class DataService : IDataService
	{
		private readonly IDataRepository<TimeSerieDataLog> _testCarbonRepository;
		private readonly AuthHttpClientFactory _clientFactory;
		private readonly string _datalogapi;
		private readonly IConfiguration _config;

		public DataService(IDataRepository<TimeSerieDataLog> testCarbonRepository, AuthHttpClientFactory clientFactory, IConfiguration config)
		{
			_config = config;
			_testCarbonRepository = testCarbonRepository;
			_clientFactory = clientFactory;
			_datalogapi = _config.GetValue<string>("DataLogUri");

		}

		public async Task<LatestDataDto> GetLatestDataByAssetAndTelemetryId(Guid assetId, Guid telemetryId, Guid tenantId)
		{
			var entity = await _testCarbonRepository.GetLatestDataByAssetAndTelemetryId(assetId, telemetryId, tenantId);
			return entity.Adapt<LatestDataDto>();
		}

		public async Task<bool> SetDesiredTelemetryValueOnDataLog(Guid assetId, Guid telemetryId, string value)
		{
			var authClient = _clientFactory.CreateAuthClient("RAM");
			var clientForAsset = authClient.HttpClient;
			clientForAsset.DefaultRequestHeaders.Accept.Clear();
			clientForAsset.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpRequestMessage httpRequestMessageToDataLog = new HttpRequestMessage();

			var uribuilder = new UriBuilder(_datalogapi + "DataLog/SetDesiredData");
			string daUrlRuleLog = uribuilder.ToString();

			httpRequestMessageToDataLog.RequestUri = new Uri(daUrlRuleLog);
			var jStr = JsonConvert.SerializeObject(new DesiredDataForDataLogDto()
			{
				AssetFilterDto = new AssetFilterForDataDto() { AssetId = assetId },
				TelemetryFilterDto = new TelemetryFilterForDataDto() { TelemetryId = telemetryId },
				ValueAsStr = value
			});
			httpRequestMessageToDataLog.Content = new StringContent(jStr, Encoding.UTF8, "application/json");
			httpRequestMessageToDataLog.Method = HttpMethod.Post;

			var resp = await _clientFactory.SendAsync(authClient, httpRequestMessageToDataLog);
			var respStr = await resp.Content.ReadAsStringAsync();
			return resp.IsSuccessStatusCode;
		}


	}
}
