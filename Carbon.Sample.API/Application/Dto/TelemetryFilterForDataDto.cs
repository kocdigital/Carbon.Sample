using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class TelemetryFilterForDataDto
	{
		public Guid TelemetryId { get; set; }
		public string TelemetryName { get; set; }
		public string TelemetryCode { get; set; }
		public Guid TenantId { get; set; }
	}

}
