using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Services.Abstract;

using MassTransit;

using Serilog;

using System.Threading.Tasks;

namespace Carbon.Sample.API.Application.Consumers
{
	public class DesiredDataConsumer : IConsumer<DesiredDataDto>
	{
		private readonly IDataService _dataService;
		public DesiredDataConsumer(IDataService dataService)
		{
			_dataService = dataService;
		}
		public async Task Consume(ConsumeContext<DesiredDataDto> context)
		{
			Log.Information($"Deisred Data Requested: AssetID:{context.Message.AssetId} - CorrelationId:{context.Message.CorrelationId}");
			await _dataService.SetDesiredTelemetryValueOnDataLog(context.Message.AssetId, context.Message.TelemetryId, context.Message.Value);
		}
	}
}
