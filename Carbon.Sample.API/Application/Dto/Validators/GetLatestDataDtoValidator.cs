using Carbon.WebApplication;

using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
	public class GetLatestDataDtoValidator : BaseDtoValidator<GetLatestDataDto>
	{
		public GetLatestDataDtoValidator()
		{
			RuleFor(x => x.AssetId).NotNull().NotEmpty();
			RuleFor(x => x.TelemetryId).NotNull().NotEmpty();

		}
	}
}
