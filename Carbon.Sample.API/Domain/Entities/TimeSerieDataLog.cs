using Carbon.TimeSeriesDb.Abstractions.Attributes;
using Carbon.TimeSeriesDb.Abstractions.Entities;

using System;

namespace Carbon.Sample.API.Domain.Entities
{
	public enum DataType
	{
		Numeric = 0,
		String = 1
	}

	public class TimeSerieDataLog : TimeSerieEntityBase
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
		[TimeSerie]
		public DateTime Date { get; set; }
		public Guid TenantId { get; set; }
		public Guid? TimeSerieDataLogLabelRelationId { get; set; }
	}


}
