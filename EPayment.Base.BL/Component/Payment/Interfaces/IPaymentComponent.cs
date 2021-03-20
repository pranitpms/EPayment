using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Interfaces
{
	public interface IPaymentComponent 
	{
		bool ProcessPayment(PaymentDTO paymentDTO);
	}
}
