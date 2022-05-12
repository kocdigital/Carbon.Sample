using Carbon.Sample.API.Domain.Entities;

using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class LatestDataDto
	{
		public Guid AssetId { get; set; }
		public String AssetName { get; set; }
		public Guid TelemetryId { get; set; }
		public String TelemetryName { get; set; }
		public string ContainerId { get; set; }
		public Guid SensorId { get; set; }
		public decimal Value { get; set; }
		public string ValueAsStr { get; set; }
		public DataType DataType { get; set; }
		public DateTime Date { get; set; }
		public Guid TenantId { get; set; }
	}
}
