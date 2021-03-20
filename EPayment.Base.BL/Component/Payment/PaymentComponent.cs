using EPayment.Base.BL.Common;
using EPayment.Base.BL.Component.Gateway;
using EPayment.Base.BL.Component.Gateway.interfaces;
using EPayment.Base.BL.Component.Interfaces;
using EPayment.Base.BL.Component.Payment;
using EPayment.Base.BL.Component.Payment.EntityObject;
using EPayment.Base.BL.Component.Payment.Interfaces;
using EPayment.Contract.Common;
using EPayment.Contract.DTO;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static EPayment.Base.BL.Common.Common;

namespace EPayment.Base.BL.Component
{
	public class PaymentComponent : BaseComponent, IPaymentComponent
	{
		#region Private Members
		private readonly IPaymentValidator PaymentValidatorComponent;
		private readonly IGatewayComponent GatewayComponent;
		private readonly IPaymentRepository PaymentRepository;
		private decimal amount;
		#endregion

		#region Constructor
		public PaymentComponent(IBaseParameter baseParameter, 
			IPaymentValidator paymentValidator,
			IGatewayComponent paymentGateway, IPaymentRepository paymentRepository) : base(baseParameter)
		{
			PaymentValidatorComponent = paymentValidator;
			GatewayComponent = paymentGateway;
			PaymentRepository = paymentRepository;
		}
		#endregion

		#region Public Members

		public IPaymentGateway PaymentGatewayComponent
		{
			get { return GatewayComponent.GetComponent(amount); }
		}

		#endregion

		#region Public Methods

		public bool ProcessPayment(PaymentDTO paymentDTO)
		{
			bool result = false;
			if (PaymentValidatorComponent.Validate(paymentDTO))
			{
				PaymentEO paymentEO = GetPaymentEO(paymentDTO);
				UpdateStatus(paymentEO, PaymentStatus.Pending);
				try
				{
					result = ProcessPaymentWithGateway(paymentDTO);
					if (result)
						UpdateStatus(paymentEO, PaymentStatus.Processed);
					else
						UpdateStatus(paymentEO, PaymentStatus.Failed);
				}
				catch(Exception exe)
				{
					AddError(PaymentErrorCode.Internal_Error, exe.Message);
				}
			}
			return result;
		}

		#endregion

		#region Private Methods
		private PaymentEO GetPaymentEO(PaymentDTO paymentDTO)
		{
			PaymentEO paymentEO = Mapper.Map<PaymentEO>(paymentDTO);
			paymentEO.PaymentStatus = new PaymentStatusEO();
			return paymentEO;
		}
		private bool ProcessPaymentWithGateway(PaymentDTO paymentDTO)
		{
			if (paymentDTO != null)
			{
				amount = paymentDTO.Amount;
				return PaymentGatewayComponent.ProcessPayment(paymentDTO);
			}
			return false;
		}

		private void UpdateStatus(PaymentEO paymentEO,string paymentStatus)
		{
			paymentEO.PaymentStatus.PatmentStatus = paymentStatus;
			PaymentRepository.SavePaymentDetails(paymentEO);
		}
		#endregion
	}
}
