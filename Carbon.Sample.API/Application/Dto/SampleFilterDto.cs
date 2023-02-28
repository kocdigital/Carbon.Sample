using Carbon.Sample.API.Application.Dto.Base;
using System;
using System.Collections.Generic;

namespace Carbon.Sample.API.Application.Dto
{
	public class SampleFilterDto : BaseRequestPagedDto<SampleFilterDto>
	{
		public IList<Guid> Ids { get; set; }
		public string Name { get; set; }
		public bool? IsActive { get; set; }
	}
}