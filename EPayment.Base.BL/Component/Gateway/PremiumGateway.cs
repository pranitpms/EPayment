using EPayment.Base.BL.Common;
using EPayment.Base.BL.Component.Gateway.interfaces;
using EPayment.Contract.Common;
using EPayment.Contract.DTO;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Gateway
{
	public class PremiumGateway : BaseComponent, IPremiumGateway
	{
		public static int count;
		public PremiumGateway(IBaseParameter baseParameter) : base(baseParameter)
		{
			count = 0;
		}

		public bool CheckHealthStatus()
		{
			return true;
		}

		public bool ProcessPayment(PaymentDTO paymentDTO)
		{
			return Policy.HandleResult<bool>(false)
				.Or<Exception>()
				.Retry<bool>(3, onRetry: (exception, retryCount) =>
				{
					if (exception != null && exception.Exception != null)
						AddError(PaymentErrorCode.Internal_Error, exception.Exception.Message);
					count++;
				})
				.Execute(() => ExecutePayment(paymentDTO));
		}

		private bool ExecutePayment(PaymentDTO paymentDTO)
		{
			if (count == 3)
				return true;
			return false;
		}
	}
}
