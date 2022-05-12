using Carbon.Common;

using System;

namespace Carbon.Sample.API.Application.Dto
{
	public interface IDesiredDataDto : IRequestDto
	{
		public Guid TenantId { get; set; }
		public Guid AssetId { get; set; }
		public Guid TelemetryId { get; set; }
		public string Value { get; set; }
	}

}
