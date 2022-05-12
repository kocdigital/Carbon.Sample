using Carbon.ExceptionHandling.Abstractions;

using System.Collections.Generic;

namespace Carbon.Sample.API.Infrastructure
{
	public class SampleException : CarbonException
	{
		public SampleException()
		{
		}

		public SampleException(ErrorCodes code) : base((int)code)
		{
		}

		public SampleException(ErrorCodes code, IList<CarbonError> errors) : base((int)code, errors)
		{
		}

		public SampleException(ErrorCodes code, object model) : base((int)code, model)
		{
		}
		public SampleException(ErrorCodes code, IList<CarbonError> errors, object model) : base((int)code, errors, model)
		{
		}
		public SampleException(ErrorCodes code, string message, params object[] args) : base((int)code, message, args)
		{
		}
	}
}
