using Carbon.WebApplication;

using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class DesiredDataDto : BaseRequestDto, IDesiredDataDto
	{
		public Guid AssetId { get; set; }
		public Guid TelemetryId { get; set; }
		public string Value { get; set; }
	}
}
