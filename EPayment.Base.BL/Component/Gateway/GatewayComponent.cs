using EPayment.Base.BL.Component.Gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static EPayment.Base.BL.Common.Common;

namespace EPayment.Base.BL.Component.Gateway
{
	public class GatewayComponent : IGatewayComponent
	{
		private readonly ICheapPaymentGateway CheapPaymentGateway;
		private readonly IExpensivePaymentGateway ExpensivePaymentGateway;
		private readonly IPremiumGateway PremiumGateway;

		public GatewayComponent(ICheapPaymentGateway cheapPaymentGateway,
			IExpensivePaymentGateway expensivePaymentGateway, 
			IPremiumGateway premiumGateway)
		{
			CheapPaymentGateway = cheapPaymentGateway;
			ExpensivePaymentGateway = expensivePaymentGateway;
			PremiumGateway = premiumGateway;
		}

		public IPaymentGateway GetComponent(decimal amount)
		{
			if (amount != decimal.MinValue)
			{
				if(amount == 20)
					return CheapPaymentGateway;
				if(amount > 20 && amount <= 500)
					return ExpensivePaymentGateway;
				if(amount > 500)
					return PremiumGateway;
			}
			return null;
		}
	}
}
