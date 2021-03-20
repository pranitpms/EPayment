using AutoMapper;
using EPayment.Contract.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Common
{
	public class BaseParameter : IBaseParameter
	{
		public IOperationOutcome ErrorBag { get; set; }
		public IMapper Mapper { get; set; }

		public BaseParameter(IOperationOutcome operationOutcome, IMapper mapper)
		{
			ErrorBag = operationOutcome;
			Mapper = mapper;
		}
	}
}
