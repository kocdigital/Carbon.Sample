using Carbon.Domain.EntityFrameworkCore;
using Carbon.PagedList;
using Carbon.Redis;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Infrastructure;
using Carbon.Sample.API.Infrastructure.Contexts.SampleContext;

using Mapster;

using Nest;

using StackExchange.Redis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Repositories
{
	public class SampleRepository : EFTenantManagedRepository<SampleEntity, SampleDBContext>, ISampleRepository
	{
		private readonly IDatabase _redisDb;
		private readonly ISampleElasticRepository _esRepo;
		public SampleRepository(SampleDBContext context, IDatabase redisDb, ISampleElasticRepository esRepo) : base(context)
		{
			_redisDb = redisDb;
			_esRepo = esRepo;
		}
		public override async Task<SampleEntity> CreateAsync(SampleEntity entity)
		{
			entity = await base.CreateAsync(entity);
			await _redisDb.Set(CacheKeyConstants.SampleEntity.GenerateKeyById(entity.Id), entity);
			await _esRepo.AddAsync(entity);
			return entity;
		}
		public override async Task<SampleEntity> GetByIdAsync(Guid id)
		{
			var cacheResult = await _redisDb.Get<SampleEntity>(CacheKeyConstants.SampleEntity.GenerateKeyById(id));
			if (cacheResult.cachedObject != null)
				return cacheResult.cachedObject;
			var entity = await base.GetByIdAsync(id);
			if (entity != null)
				await _redisDb.Set(CacheKeyConstants.SampleEntity.GenerateKeyById(id), entity);
			return entity;
		}
		public override async Task<SampleEntity> UpdateAsync(SampleEntity entity)
		{
			var updatedEntity = await base.UpdateAsync(entity);
			await _redisDb.Set(CacheKeyConstants.SampleEntity.GenerateKeyById(updatedEntity.Id), updatedEntity);
			await _esRepo.UpdateAsync(entity);
			return updatedEntity;
		}
		public override async Task<SampleEntity> DeleteAsync(Guid id)
		{
			var entity = await base.DeleteAsync(id);
			if (entity != null)
			{
				await _redisDb.RemoveKey(CacheKeyConstants.SampleEntity.GenerateKeyById(entity.Id));
				await _esRepo.DeleteByIdAsync(id.ToString());
			}
			return entity;
		}
		public async Task<IPagedList<SampleDto>> Filter(SampleFilterDto filterDto)
		{
			var filters = new List<Func<QueryContainerDescriptor<SampleEntity>, QueryContainer>>();

			filters.Add(r => r.Term(c => c
							.Field(x => x.TenantId)
							.Value(filterDto.TenantId)));

			if (filterDto.Ids?.Any(x => x != Guid.Empty) ?? false)
			{
				filters.Add(r => r.Terms(c => c
								.Field(x => x.Id)
								.Terms(filterDto.Ids.Where(x => x != Guid.Empty)))
						 );
			}
			if (!string.IsNullOrWhiteSpace(filterDto.Name))
			{
				filters.Add(r => r.Terms(c => c
								.Field(x => x.Name)
								.Terms(filterDto.Name))
						 );
			}
			if (filterDto.IsActive.HasValue)
			{
				filters.Add(r => r.Terms(c => c
								.Field(x => x.IsActive)
								.Terms(filterDto.IsActive.Value))
						 );
			}
			//ES paging is bit problematic, if you use paged data use with caution
			var results = await _esRepo.FilterAsync(filters);
			return new PagedList<SampleDto>(results.Select(x => x.Adapt<SampleDto>()).ToList(), filterDto.PageIndex, filterDto.PageSize);
		}
	}
}
