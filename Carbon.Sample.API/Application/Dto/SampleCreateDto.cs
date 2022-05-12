using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class SampleCreateDto
	{
		public string Name { get; set; }
		public Guid TenantId { get; set; }
	}
}
