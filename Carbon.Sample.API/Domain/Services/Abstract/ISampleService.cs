using Carbon.PagedList;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Application.Dto.Base;
using Carbon.WebApplication.TenantManagementHandler.Interfaces;
using System;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Services.Abstract
{
    public interface ISampleService : ISolutionFilteredService, IOwnershipFilteredService
    {
        Task<SampleDto> CreateAsync(SampleCreateDto dto);
        Task<SampleDto> UpdateAsync(SampleUpdateDto dto);
        Task DeleteAsync(SampleDeleteDto dto);
        Task<SampleDto> GetByIdAsync(Guid id, Guid tenantId);
        Task<Paged<SampleDto>> GetAllAsync(SampleFilterDto filter);
    }
}
