using Carbon.PagedList;
using Carbon.Sample.API.Application.Dto;
using Carbon.Sample.API.Domain.Services.Abstract;
using Carbon.Sample.API.Infrastructure;
using Carbon.WebApplication;
using Carbon.WebApplication.HttpAtrributes;
using Carbon.WebApplication.TenantManagementHandler.ControllerAttributes;
using Carbon.WebApplication.TenantManagementHandler.Interfaces;

using HybridModelBinding;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Carbon.Sample.API.Application.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class SampleController : CarbonTenantManagedController
	{
		private readonly ISampleService _sampleService;
		public SampleController(ISampleService sampleService) : base(new List<ISolutionFilteredService>() { sampleService }, new List<IOwnershipFilteredService>() { sampleService })
		{
			_sampleService = sampleService;
		}

		/// <summary>
		/// Get all Samples by filter with Get HTTP Method
		/// </summary>
		/// <param name="tenantId">Tenant Id</param>
		/// <param name="sampleFilterDto">Sample Filter</param>
		/// <returns>Sample List</returns>
		[HttpGetCarbon]
		//[Route("GetSamples")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(IPagedList<SampleDto>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[SolutionFilter]
		[OwnershipFilter("Sample_Read")]
		public async Task<IActionResult> GetSamples([FromHeader] Guid tenantId, [FromHybrid] SampleFilterDto sampleFilterDto)
		{
			if (tenantId == Guid.Empty)
				throw new SampleException(ErrorCodes.NoTenantSpecified);
			try
			{
				var Samples = await _sampleService.Filter(sampleFilterDto);
				return PagedListOk(Samples);
			}
			catch (KeyNotFoundException)
			{
				return NotFound();
			}
		}

		/// <summary>
		/// Create Sample
		/// </summary>
		/// <param name="model">Sample creator model</param>
		/// <param name="tenantId">Tenant Id</param>
		/// <returns>Created Sample's Id</returns>
		[HttpPostCarbon]
		//[Route("CreateSample")]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[SolutionFilter]
		[OwnershipFilter("Sample_Create")]
		public async Task<IActionResult> CreateSample([FromBody] SampleCreateDto model, [FromHeader] Guid tenantId)
		{
			model.TenantId = tenantId;
			var result = await _sampleService.CreateAsync(model);

			return CreatedAtAction(nameof(CreateSample), new { id = result.Id }, new { id = result.Id });
		}

		/// <summary>
		/// Updates Sample
		/// </summary>
		/// <param name="model">Sample updater model</param>
		/// <param name="tenantId">Tenant Id</param>
		/// <param name="id">Updated Sample id</param>
		/// <returns>Sample's last state</returns>
		[HttpPutCarbon]
		[Route("{id:Guid}")]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[SolutionFilter]
		[OwnershipFilter("Sample_Update")]
		public async Task<IActionResult> UpdateSample([FromBody] SampleUpdateDto model, [FromHeader] Guid tenantId, Guid id)
		{
			model.Id = id;
			model.TenantId = tenantId;
			var result = await _sampleService.UpdateAsync(model);
			return Ok(result);
		}

		/// <summary>
		/// Deletes the Sample given by id
		/// </summary>
		/// <param name="id">Sample id</param>
		/// <param name="tenantId">Tenant Id</param>
		/// <returns>No Content</returns>
		[HttpDeleteCarbon]
		[Route("{id:Guid}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[SolutionFilter]
		[OwnershipFilter("Sample_Delete")]
		public async Task<IActionResult> DeleteSample([FromBody] SampleDeleteDto model, Guid id, [FromHeader] Guid tenantId)
		{
			model.Id = id;
			model.TenantId = tenantId;

			try
			{
				await _sampleService.DeleteAsync(model);
				return DeletedOk();
			}
			catch (SampleException ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
