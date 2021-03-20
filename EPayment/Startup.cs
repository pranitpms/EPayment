using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EPayment.Base.BL.Common;
using EPayment.Base.BL.Component.Payment.Configurations;
using EPayment.Base.BL.Configuration;
using EPayment.Base.BL.Contexts;
using EPayment.Base.BL.Facade;
using EPayment.Contract.Common;
using EPayment.Contract.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;

namespace EPayment
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddDbContext<PaymentDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("dbConnection")));
			services.AddAutoMapper(typeof(PaymentProfile));

			services.AddScoped<IOperationOutcome, OperationOutcome>();
			services.AddScoped<IBaseParameter, BaseParameter>();
			services.AddComponent();
			services.AddRepository();
			services.AddTransient<IPaymentService, PaymentFacade>();
		}
		//AppDomain.CurrentDomain.GetAssemblies()
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			//StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
