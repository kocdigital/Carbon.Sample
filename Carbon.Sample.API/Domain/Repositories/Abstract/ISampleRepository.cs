using Carbon.Common.TenantManagementHandler.Interfaces;
using Carbon.Domain.Abstractions.Repositories;
using Carbon.Sample.API.Domain.Entities;
using System.Threading.Tasks;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Application.Dto.Base;
using System.Linq.Expressions;
using System;

namespace Carbon.Sample.API.Domain.Repositories.Abstract
{
    public interface ISampleRepository : IRepository<SampleEntity>, ISolutionFilteredRepository, IOwnershipFilteredRepository
    {
        Task<SampleEntity> GetByIdAsync(Expression<Func<SampleEntity, bool>> filters);
        Task<Paged<SampleEntity>> GetAllAsync(SampleFilterDto filter);
    }
}