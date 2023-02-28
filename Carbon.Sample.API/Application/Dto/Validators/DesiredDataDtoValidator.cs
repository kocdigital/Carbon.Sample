using Carbon.Sample.API.Application.Dto.Validators.Base;
using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
    public class DesiredDataDtoValidator : BaseRequestValidator<DesiredDataDto>
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
