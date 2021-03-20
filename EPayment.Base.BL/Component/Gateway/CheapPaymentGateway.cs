using System;
using System.Collections.Generic;
using System.Text;
using EPayment.Contract.DTO;

namespace EPayment.Base.BL.Component.Gateway.interfaces
{
	public class CheapPaymentGateway : ICheapPaymentGateway
	{
		public bool CheckHealthStatus()
		{
			return true;
		}

		public bool ProcessPayment(PaymentDTO paymentDTO)
		{
			return true;
		}
	}
}
