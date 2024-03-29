﻿using Carbon.Common.TenantManagementHandler.Interfaces;
using Carbon.PagedList;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Domain.Services.Abstract;
using Carbon.WebApplication.TenantManagementHandler.Abstracts;

using Mapster;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Domain.Services
{
	public class SampleService : TenantManagedServiceBase, ISampleService
	{
		private readonly ISampleRepository _sampleRepository;
		public SampleService(ISampleRepository sampleRepository)
			: base(new List<ISolutionFilteredRepository>() { sampleRepository }, new List<IOwnershipFilteredRepository>() { sampleRepository })
		{
			_sampleRepository = sampleRepository;
		}
		public async Task<SampleDto> CreateAsync(SampleCreateDto dto)
		{
			//Do bussiness related operations here
			var entity = dto.Adapt<SampleEntity>();
			await _sampleRepository.CreateAsync(entity);
			var result = entity.Adapt<SampleDto>();

			return result;
		}

		public async Task<SampleDto> UpdateAsync(SampleUpdateDto dto)
		{
			//Do bussiness related operations here
			var entity = dto.Adapt<SampleEntity>();
			await _sampleRepository.UpdateAsync(entity);
			var result = entity.Adapt<SampleDto>();

			return result;
		}

		public async Task DeleteAsync(SampleDeleteDto dto)
		{
			//Do bussiness related operations here
			if (dto.Id.HasValue)
				await _sampleRepository.DeleteAsync(dto.Id.Value);
			else
			{
				var entity = await _sampleRepository.GetAsync(x => x.Name == dto.Name);
				if (entity != null)
					await _sampleRepository.DeleteAsync(entity.Id);
			}
		}

		public async Task<IPagedList<SampleDto>> Filter(SampleFilterDto dto)
		{
			//Do bussiness related operations here
			return await _sampleRepository.Filter(dto);
		}
	}
}
