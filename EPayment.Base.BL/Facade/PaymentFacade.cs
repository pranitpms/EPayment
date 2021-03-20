using EPayment.Base.BL.Component.Interfaces;
using EPayment.Contract.DTO;
using EPayment.Contract.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Facade
{
	public class PaymentFacade : IPaymentService
	{
		private readonly IPaymentComponent PaymentComponent;
		public PaymentFacade(IPaymentComponent paymentComponent)
		{
			PaymentComponent = paymentComponent;
		}

		public bool ProcessPayment(PaymentDTO paymentDTO)
		{
			return PaymentComponent.ProcessPayment(paymentDTO);
		}
	}
}
