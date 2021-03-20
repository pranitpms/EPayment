using EPayment.Base.BL.Component.Payment.EntityObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Contexts
{
	public class PaymentDbContext : DbContext
	{
		public PaymentDbContext(DbContextOptions options): base(options)
		{ }

		public DbSet<PaymentEO> PaymentDbSet { get; set; }
		public DbSet<PaymentStatusEO> PaymentStatusDbSet { get; set; }
	}
}
