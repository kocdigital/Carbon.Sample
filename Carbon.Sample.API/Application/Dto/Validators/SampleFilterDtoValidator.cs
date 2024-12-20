﻿using Carbon.WebApplication;

using FluentValidation;

using System;
using System.Linq;

namespace Carbon.Sample.API.Application.Dto.Validators
{
	public class SampleFilterDtoValidator : BaseDtoValidator<SampleFilterDto>
	{
		public SampleFilterDtoValidator()
		{
			RuleFor(x => x.IdList).Must(x => x == null || !x.Any(y => !string.IsNullOrWhiteSpace(y)));
			//RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.TenantId).NotEmpty();
		}
	}
}
