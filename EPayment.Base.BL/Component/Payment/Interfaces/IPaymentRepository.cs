using EPayment.Base.BL.Component.Payment.EntityObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.Interfaces
{
	public interface IPaymentRepository
	{
		bool SavePaymentDetails(PaymentEO paymentEO);
	}
}
