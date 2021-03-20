using EPayment.Base.BL.Component;
using EPayment.Base.BL.Component.Gateway.interfaces;
using EPayment.Base.BL.Component.Payment.Interfaces;
using EPayment.Contract.DTO;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Component.Payment
{
	public class PaymentComponentTest : UnitTest
	{
		#region Private Member
		private Mock<IPaymentValidator> paymentValidatorComponentMock;
		private Mock<IGatewayComponent> gatewayComponentMock;
		private Mock<IPaymentRepository> paymentRepositoryMock;
		private Mock<IPaymentGateway> paymentGatewayMock;
		private PaymentComponent paymentComponent;
		#endregion

		#region Constructor
		public PaymentComponentTest()
		{
			Initialize();
			
		}
		#endregion

		#region Facts
		[Fact(DisplayName = "Process Payment Null Request")]
		public void TestProcessPayment_NullRequest()
		{
			SetupValidation(false);
			var result = paymentComponent.ProcessPayment(null);
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment Invalid Request")]
		public void TestProcessPayment_InvalidRequest()
		{
			SetupValidation(false);
			var result = paymentComponent.ProcessPayment(new PaymentDTO());
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return false")]
		public void TestProcessPayment_ReturnsFalse()
		{
			SetupValidation(true);
			SetUpGatewayComponent();
			var result = paymentComponent.ProcessPayment(new PaymentDTO());
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return true")]
		public void TestProcessPayment_ReturnsTrue()
		{
			SetupValidation(true);
			SetUpGatewayComponent();
			SetupPaymentGateway(true);
			var result = paymentComponent.ProcessPayment(new PaymentDTO());
			result.Should().BeTrue();
		}

		[Fact(DisplayName = "Process Payment Exception")]
		public void TestProcessPayment_Exception()
		{
			SetupValidation(true);
			SetUpGatewayComponent();
			paymentGatewayMock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDTO>())).Throws(new Exception());
			var result = paymentComponent.ProcessPayment(new PaymentDTO());
			result.Should().BeFalse();
			BaseParameters.ErrorBag.OperationOutcomeCode.Should().Equals("Error");
			BaseParameters.ErrorBag.Issues.Should().NotBeNullOrEmpty();
		}

		#endregion

		#region Private Methods
		private void Initialize()
		{
			paymentValidatorComponentMock = new Mock<IPaymentValidator>();
			gatewayComponentMock = new Mock<IGatewayComponent>();
			paymentRepositoryMock = new Mock<IPaymentRepository>();
			paymentGatewayMock = new Mock<IPaymentGateway>();
			paymentComponent = new PaymentComponent(BaseParameters,
				paymentValidatorComponentMock.Object,
				gatewayComponentMock.Object,
				paymentRepositoryMock.Object);
		}

		private void SetupValidation(bool isValid)
		{
			paymentValidatorComponentMock.Setup(x=>x.Validate(It.IsAny<PaymentDTO>())).Returns(isValid);
		}

		private void SetUpGatewayComponent()
		{
			gatewayComponentMock.Setup(x => x.GetComponent(It.IsAny<decimal>())).Returns(paymentGatewayMock.Object);
		}

		private void SetupPaymentGateway(bool isPorcess)
		{
			paymentGatewayMock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDTO>())).Returns(isPorcess);
		}
		#endregion
	}
}
