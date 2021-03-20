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
	public class ExpensivePaymentGateway : BaseComponent,IExpensivePaymentGateway
	{
		private ICheapPaymentGateway cheapPaymentGateway;
		private static int Count;

		public ICheapPaymentGateway CheapPaymentGateway
		{
			get { return cheapPaymentGateway = cheapPaymentGateway ?? new CheapPaymentGateway(); }
			set { cheapPaymentGateway = value; }
		}
		public ExpensivePaymentGateway(IBaseParameter baseParameter):base(baseParameter)
		{
			Count = 0;
		}
		public bool CheckHealthStatus()
		{
			if (Count == 0)
				return false;
			else
				return true;
		}

		public bool ProcessPayment(PaymentDTO paymentDTO)
		{
			return Policy.HandleResult<bool>(false)
				.Or<Exception>()
				.Retry<bool>(1, onRetry: (exception, retryCount) =>
				{
					if(exception != null && exception.Exception != null)
						AddError(PaymentErrorCode.Internal_Error, exception.Exception.Message);
					Count++;
				})
				.Execute(() => RetryAndProcessPayment(paymentDTO));
		}

		private bool RetryAndProcessPayment(PaymentDTO paymentDTO)
		{
			if(CheckHealthStatus())
			{
				return CheapPaymentGateway.ProcessPayment(paymentDTO);
			}
			return false;
		}
	}
}
