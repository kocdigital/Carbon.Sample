using Carbon.Common;
using Carbon.Domain.EntityFrameworkCore;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Application.Dto.Base;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Infrastructure.Contexts.SampleContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Repositories
{
    public class SampleRepository : EFTenantManagedRepository<SampleEntity, SampleDBContext>, ISampleRepository
    {
        public SampleRepository(SampleDBContext context) : base(context)
        {
        }

        public override async Task<SampleEntity> CreateAsync(SampleEntity entity)
        {
            entity = await base.CreateAsync(entity);
            return entity;
        }

        public async Task<SampleEntity> GetByIdAsync(Expression<Func<SampleEntity, bool>> filters)
        {
            var entity = await context.SampleEntity.FirstOrDefaultAsync(filters);
            return entity;
        }

        public override async Task<SampleEntity> UpdateAsync(SampleEntity entity)
        {
            var updatedEntity = await base.UpdateAsync(entity);
            return updatedEntity;
        }

        public override async Task<SampleEntity> DeleteAsync(Guid id)
        {
            var entity = await base.DeleteAsync(id);
            return entity;
        }

        public async Task<Paged<SampleEntity>> GetAllAsync(SampleFilterDto filter)
        {
            var query = context.SampleEntity
                .AsNoTracking()
                .Where(x => !x.IsDeleted);

            if (filter.TenantId != Guid.Empty)
            {
                query = query.Where(x => x.TenantId == filter.TenantId);
            }

            if (filter.Ids != null && filter.Ids.Count > 0)
            {
                query = query.Where(x => filter.Ids.Contains(x.Id));
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == filter.IsActive);
            }

            query = query.OrderBy(filter.Orderables);

            int totalPagesCount = 1;
            var totalDataCount = query.Count();

            if (filter.PageSize != 0)
            {
                totalPagesCount = query.CalculatePageCount(filter.PageSize);
                query = query.SkipTake(filter.PageIndex, filter.PageSize);
            }

            var result = await query.ToListAsync();

            return new Paged<SampleEntity>
            {
                List = result,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                TotalPageCount = totalPagesCount,
                TotalCount = totalDataCount
            };
        }
    }
}