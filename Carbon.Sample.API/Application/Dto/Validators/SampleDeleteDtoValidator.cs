using Carbon.WebApplication;

using FluentValidation;

using System;

namespace Carbon.Sample.API.Application.Dto.Validators
{
	public class SampleDeleteDtoValidator : BaseDtoValidator<SampleDeleteDto>
	{
		public SampleDeleteDtoValidator()
		{
			RuleFor(x => x.Id).NotEmpty().When(x => string.IsNullOrWhiteSpace(x.Name));
			RuleFor(x => x.Name).NotEmpty().When(x => x.Id == null || x.Id == Guid.Empty);
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
