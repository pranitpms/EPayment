using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Services
{
	public interface IPaymentService
	{
		bool ProcessPayment(PaymentDTO paymentDTO);
	}
}
