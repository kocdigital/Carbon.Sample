using Carbon.Common;
using Carbon.Domain.Abstractions.Entities;

using System;
using System.Collections.Generic;

namespace Carbon.Sample.API.Domain.Entities
{
	public class SampleEntity :
		IEntity,
		IPassivable,
		ISoftDelete,
		IMustHaveTenant,
		IUpdateAuditing,
		IDeleteAuditing,
		IInsertAuditing,
		IHaveOwnership<EntitySolutionRelation>
	{
		public SampleEntity()
		{

		}
		public string Name { get; set; }

		//Those below comes from interfaces
		public Guid Id { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public Guid TenantId { get; set; }
		public string UpdatedUser { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string DeletedUser { get; set; }
		public DateTime? DeletedDate { get; set; }
		public string InsertedUser { get; set; }
		public DateTime? InsertedDate { get; set; }


		#region IHaveOwnership
		public Guid OwnerId { get; set; }
		public Guid OrganizationId { get; set; }
		public OwnerType OwnerType { get; set; }
		public ICollection<EntitySolutionRelation> RelationalOwners { get; set; }

		public SampleEntity(int ObjectTypeCode)
		{
			this._objectTypeCode = ObjectTypeCode;
		}
		private int _objectTypeCode { get; set; }
		public int GetObjectTypeCode()
		{
			return _objectTypeCode;
		}
		#endregion
	}
}
