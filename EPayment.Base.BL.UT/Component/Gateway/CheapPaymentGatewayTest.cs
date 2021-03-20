using EPayment.Base.BL.Component.Gateway.interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Component.Gateway
{
	public class CheapPaymentGatewayTest
	{
		[Fact]
		public void TestCheckHealthStatus()
		{
			var result = new CheapPaymentGateway().CheckHealthStatus();
			result.Should().BeTrue();
		}

		[Fact]
		public void TestProcessPayment()
		{
			var result = new CheapPaymentGateway().ProcessPayment(new Contract.DTO.PaymentDTO());
			result.Should().BeTrue();
		}
	}
}
