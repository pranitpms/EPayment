using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Gateway.interfaces
{
	public interface IPaymentGateway 
	{
		bool CheckHealthStatus();
		bool ProcessPayment(PaymentDTO paymentDTO);
	}
}
