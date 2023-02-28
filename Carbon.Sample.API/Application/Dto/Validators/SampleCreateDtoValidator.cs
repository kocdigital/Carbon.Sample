using Carbon.Sample.API.Application.Dto.Validators.Base;
using Carbon.WebApplication;

using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
    public class SampleCreateDtoValidator : BaseRequestValidator<SampleCreateDto>
	{
		public SampleCreateDtoValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
