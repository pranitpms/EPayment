using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.Interfaces
{
	public interface IPaymentValidator
	{
		bool Validate(PaymentDTO paymentDTO);
	}
}
