using Carbon.WebApplication;

using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
	public class SampleCreateDtoValidator : BaseDtoValidator<SampleCreateDto>
	{
		public SampleCreateDtoValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
