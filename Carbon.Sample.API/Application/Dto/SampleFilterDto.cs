using Carbon.Common;
using Carbon.Domain.Abstractions.Data;

using System;
using System.Collections.Generic;

namespace Carbon.Sample.API.Application.Dto
{
	public class SampleFilterDto : IOrderableData, IPageableData
	{
		public IList<Guid> Ids { get; set; }
		public string Name { get; set; }
		public bool? IsActive { get; set; }
		public Guid TenantId { get; set; }
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public IList<Orderable> Orderables { get; set; }
	}
}
