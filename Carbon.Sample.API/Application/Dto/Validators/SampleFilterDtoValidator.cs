using Carbon.Sample.API.Application.Dto.Validators.Base;
using FluentValidation;
using System;
using System.Linq;

namespace Carbon.Sample.API.Application.Dto.Validators
{
    public class SampleFilterDtoValidator : BaseRequestValidator<SampleFilterDto>
	{
		public SampleFilterDtoValidator()
		{
			RuleFor(x => x.Ids).Must(x => x == null || !x.Any(y => y != Guid.Empty));
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
