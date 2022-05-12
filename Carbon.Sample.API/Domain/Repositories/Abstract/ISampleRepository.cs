using Carbon.Common.TenantManagementHandler.Interfaces;
using Carbon.Domain.Abstractions.Repositories;
using Carbon.PagedList;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Entities;

using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Repositories.Abstract
{
	public interface ISampleRepository : IRepository<SampleEntity>, ISolutionFilteredRepository, IOwnershipFilteredRepository
	{
		Task<IPagedList<SampleDto>> Filter(SampleFilterDto filterDto);
	}
}
