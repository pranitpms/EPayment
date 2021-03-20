using AutoMapper;
using EPayment.Contract.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Common
{
	public abstract class BaseComponent
	{
		protected IBaseParameter BaseParameters { get; set; }
		protected IMapper Mapper { get; set; }
		public BaseComponent(IBaseParameter baseParameter)
		{
			BaseParameters = baseParameter;
			Mapper = baseParameter.Mapper;
		}

		protected void AddError(PaymentErrorCode paymentErrorCode,string message, params object[] errorParams)
		{
			BaseParameters.ErrorBag.AddError((int)paymentErrorCode, message, errorParams);
		}
	}
}
