using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class SampleDeleteDto
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public Guid TenantId { get; set; }
	}
}
