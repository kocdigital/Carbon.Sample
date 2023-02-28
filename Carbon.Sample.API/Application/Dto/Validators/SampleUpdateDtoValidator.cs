using Carbon.Sample.API.Application.Dto.Validators.Base;
using FluentValidation;

namespace Carbon.Sample.API.Application.Dto.Validators
{
    public class SampleUpdateDtoValidator : BaseRequestValidator<SampleUpdateDto>
    {
        public SampleUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.TenantId).NotEmpty();
        }
    }
}
