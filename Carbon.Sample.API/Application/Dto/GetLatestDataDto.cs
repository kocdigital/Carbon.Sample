using Microsoft.AspNetCore.Mvc;

using System;
using System.Text.Json.Serialization;

namespace Carbon.Sample.API.Application.Dto
{
	public class GetLatestDataDto
	{
		[FromQuery]
		[JsonIgnore]
		public Guid TelemetryId { get; set; }
		[FromQuery]
		[JsonIgnore]
		public Guid AssetId { get; set; }
	}
}
