using EPayment.Base.BL.Component.Interfaces;
using EPayment.Base.BL.Facade;
using EPayment.Contract.DTO;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Facade
{
	public class PaymentFacadeTest: UnitTest
	{
		private Mock<IPaymentComponent> paymentComponentMock;
		public PaymentFacade paymentFacade;
		public PaymentFacadeTest()
		{
			paymentComponentMock = new Mock<IPaymentComponent>();
			paymentFacade = new PaymentFacade(paymentComponentMock.Object);
		}

		#region Facts
		[Fact(DisplayName = "Process Payment Null Request")]
		public void TestProcessPayment_NullRequest()
		{
			SetUpGatewayComponent(false);
			var result = paymentFacade.ProcessPayment(null);
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment Invalid Request")]
		public void TestProcessPayment_InvalidRequest()
		{
			SetUpGatewayComponent(false);
			var result = paymentFacade.ProcessPayment(new PaymentDTO());
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return false")]
		public void TestProcessPayment_ReturnsFalse()
		{
			SetUpGatewayComponent(false);
			var result = paymentFacade.ProcessPayment(new PaymentDTO());
			result.Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return true")]
		public void TestProcessPayment_ReturnsTrue()
		{
			SetUpGatewayComponent(true);
			var result = paymentFacade.ProcessPayment(new PaymentDTO());
			result.Should().BeTrue();
		}

		#endregion

		#region Private Method
		private void SetUpGatewayComponent(bool isProcess)
		{
			paymentComponentMock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDTO>())).Returns(isProcess);
		}
		#endregion
	}
}
