using System;

namespace Carbon.Sample.API.Application.Dto
{
	public class SampleDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public Guid TenantId { get; set; }
		public string InsertedUser { get; set; }
		public DateTime? InsertedDate { get; set; }
		public string UpdatedUser { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string DeletedUser { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
