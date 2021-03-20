using EPayment.Base.BL.Component.Payment.EntityObject;
using EPayment.Base.BL.Component.Payment.Interfaces;
using EPayment.Base.BL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.Repository
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly PaymentDbContext _paymentDbContext;
		public PaymentRepository(PaymentDbContext paymentDbContext)
		{
			_paymentDbContext = paymentDbContext;
		}

		public bool SavePaymentDetails(PaymentEO paymentEO)
		{
			bool isSaved = false;
			if (paymentEO != null)
			{
				paymentEO.PaymentDate = DateTime.Now;
				if (paymentEO.PaymentId > 0)
					_paymentDbContext.PaymentDbSet.Update(paymentEO);
				else
					_paymentDbContext.PaymentDbSet.Add(paymentEO);
				isSaved = _paymentDbContext.SaveChanges()>0;
			}
			return isSaved;
		}

		public bool SavePaymentDetails(PaymentEO paymentEO, PaymentStatusEO paymentStatusEO)
		{
			bool isSaved = false;
			if (paymentEO != null)
			{
				paymentEO.PaymentDate = DateTime.Now;
				paymentEO.PaymentStatus = paymentStatusEO;
				isSaved = SavePaymentDetails(paymentEO);
			}
			return isSaved;
		}
	}
}
