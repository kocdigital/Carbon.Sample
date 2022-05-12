using Carbon.PagedList;
using Carbon.Sample.API.Application.Dto;
using Carbon.WebApplication.TenantManagementHandler.Interfaces;

using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Services.Abstract
{
	public interface ISampleService : ISolutionFilteredService, IOwnershipFilteredService
	{
		Task<SampleDto> CreateAsync(SampleCreateDto dto);

		Task<SampleDto> UpdateAsync(SampleUpdateDto dto);

		Task DeleteAsync(SampleDeleteDto dto);
		Task<IPagedList<SampleDto>> Filter(SampleFilterDto dto);
	}
}
