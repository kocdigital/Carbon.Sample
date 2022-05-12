using System;
using System.Text.Json.Serialization;

namespace Carbon.Sample.API.Application.Dto
{
	public class DesiredDataForDataLogDto
	{
		public TelemetryFilterForDataDto TelemetryFilterDto { get; set; }
		public AssetFilterForDataDto AssetFilterDto { get; set; }
		public decimal Value { get; set; }
		public string ValueAsStr { get; set; }
		[JsonIgnore]
		public Guid TenantId { get; set; }
	}

}
