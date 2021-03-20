using EPayment.Base.BL.Component.Gateway;
using EPayment.Base.BL.Component.Gateway.interfaces;
using EPayment.Contract.DTO;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Component.Gateway
{
	public class ExpensivePaymentGatewayTest : UnitTest
	{
		private Mock<ICheapPaymentGateway> cheapPaymentGatewayMock;
		private ExpensivePaymentGateway expensivePaymentGateway;

		public ExpensivePaymentGatewayTest()
		{
			cheapPaymentGatewayMock = new Mock<ICheapPaymentGateway>();
			expensivePaymentGateway = new ExpensivePaymentGateway(BaseParameters)
			{
				CheapPaymentGateway = cheapPaymentGatewayMock.Object
			};
		}

		[Fact]
		public void TestProcessPayment()
		{
			cheapPaymentGatewayMock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDTO>())).Returns(true);
			var result = expensivePaymentGateway.ProcessPayment(new Contract.DTO.PaymentDTO());
			result.Should().BeTrue();
		}
	}
}
