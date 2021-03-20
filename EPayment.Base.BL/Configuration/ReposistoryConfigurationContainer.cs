using EPayment.Base.BL.Component.Payment.Interfaces;
using EPayment.Base.BL.Component.Payment.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Configuration
{
	public static class ReposistoryConfigurationContainer
	{
		public static IServiceCollection AddRepository(this IServiceCollection services)
		{
			services.AddScoped<IPaymentRepository, PaymentRepository>();
			return services;
		}
	}
}
