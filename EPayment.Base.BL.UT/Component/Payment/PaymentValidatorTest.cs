using EPayment.Base.BL.Component.Payment;
using EPayment.Contract.DTO;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Component.Payment
{
	public class PaymentValidatorTest : UnitTest
	{
		#region Private Member
		private PaymentValidator paymentValidator;
		#endregion

		#region Constructor
		public PaymentValidatorTest()
		{
			Initialize();
		}
		#endregion

		#region Facts
		[Fact(DisplayName = "Invalid Card Number")]
		public void TestValidate_InvalidCardNumber()
		{
			PaymentDTO paymentDTO = GetPaymentDTO();
			paymentDTO.CreditCardNumber = null;
			var result = paymentValidator.Validate(paymentDTO);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Invalid Expiration Date")]
		public void TestValidate_InvalidExpirationDate()
		{
			PaymentDTO paymentDTO = GetPaymentDTO();
			paymentDTO.ExpirationDate = new DateTime(1990,01,01);
			var result = paymentValidator.Validate(paymentDTO);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Invalid Card HolderName ")]
		public void TestValidate_InvalidCardHolder()
		{
			PaymentDTO paymentDTO = GetPaymentDTO();
			paymentDTO.CardHolder = null;
			var result = paymentValidator.Validate(paymentDTO);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Invalid SecurityCOde")]
		public void TestValidate_InvalidSecurityCode()
		{
			PaymentDTO paymentDTO = GetPaymentDTO();
			paymentDTO.SecurityCode = "123456789";
			var result = paymentValidator.Validate(paymentDTO);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Invalid Payment Amount")]
		public void TestValidate_InvalidAmount()
		{
			PaymentDTO paymentDTO = GetPaymentDTO();
			paymentDTO.Amount = -12;
			var result = paymentValidator.Validate(paymentDTO);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Invalid Request")]
		public void TestValidate_InvalidDTO()
		{
			var result = paymentValidator.Validate(null);
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
		}

		[Fact(DisplayName = "Valid Request")]
		public void TestValidate_Valid()
		{
			var result = paymentValidator.Validate(GetPaymentDTO());
			result.Should().BeTrue();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Success");
		}
		#endregion

		#region Private Methods
		private void Initialize()
		{
			paymentValidator = new PaymentValidator(BaseParameters);
		}

		private PaymentDTO GetPaymentDTO()
		{
			return new PaymentDTO
			{
				CreditCardNumber = "5172548563225859",
				CardHolder = "Pranit",
				ExpirationDate = new DateTime(2025, 5, 1),
				Amount = 20
			};
		}
		
		#endregion
	}
}
