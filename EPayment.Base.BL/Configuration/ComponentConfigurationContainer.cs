using EPayment.Base.BL.Component;
using EPayment.Base.BL.Component.Gateway;
using EPayment.Base.BL.Component.Gateway.interfaces;
using EPayment.Base.BL.Component.Interfaces;
using EPayment.Base.BL.Component.Payment;
using EPayment.Base.BL.Component.Payment.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Configuration
{
	public static class ComponentConfigurationContainer
	{
		public static IServiceCollection AddComponent(this IServiceCollection services)
		{
			services.AddScoped<IPaymentComponent, PaymentComponent>();
			services.AddScoped<IPaymentValidator, PaymentValidator>();
			services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
			services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
			services.AddScoped<IPremiumGateway, PremiumGateway>();
			services.AddScoped<IGatewayComponent, GatewayComponent>();
			return services;
		}
	}
}
