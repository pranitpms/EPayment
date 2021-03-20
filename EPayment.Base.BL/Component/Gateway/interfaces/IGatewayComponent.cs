using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Gateway.interfaces
{
	public interface IGatewayComponent
	{
		IPaymentGateway GetComponent(decimal amount);
	}
}
