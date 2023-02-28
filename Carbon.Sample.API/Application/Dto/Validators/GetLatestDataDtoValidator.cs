using Carbon.Sample.API.Application.Dto.Validators.Base;
using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
    public class GetLatestDataDtoValidator : BaseRequestValidator<GetLatestDataDto>
	{
		public GetLatestDataDtoValidator()
		{
			RuleFor(x => x.AssetId).NotNull().NotEmpty();
			RuleFor(x => x.TelemetryId).NotNull().NotEmpty();
		}
	}
}