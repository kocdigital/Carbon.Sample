using Carbon.Sample.API.Infrastructure;
using FluentValidation.Results;
using FluentValidation;
using Carbon.Sample.API.Application.Dto.Base;
using Carbon.WebApplication;

namespace Carbon.Sample.API.Application.Dto.Validators.Base
{
    //TO DO: Moved to carbon.
    public class BaseRequestValidator<T> : BaseDtoValidator<T>
    {
        public BaseRequestValidator()
        {

        }
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure()
                {
                    ErrorMessage = "Dto cannot be null!",
                    ErrorCode = ErrorCodes.DtoCannotBeNull.ToString()
                });
                return false;
            }
            return true;
        }
    }
}
