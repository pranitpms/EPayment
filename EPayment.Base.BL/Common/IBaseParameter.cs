using AutoMapper;
using EPayment.Contract.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Common
{
	public interface IBaseParameter
	{
		IOperationOutcome ErrorBag { get; set; }
		IMapper Mapper { get; set; }
	}
}
