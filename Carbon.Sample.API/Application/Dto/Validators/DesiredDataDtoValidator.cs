using Carbon.WebApplication;

using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
	public class DesiredDataDtoValidator : BaseDtoValidator<DesiredDataDto>
	{
		public DesiredDataDtoValidator()
		{
			RuleFor(x => x.AssetId).NotEmpty();
			RuleFor(x => x.TelemetryId).NotEmpty();

			RuleFor(x => x.Value).NotEmpty();
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
