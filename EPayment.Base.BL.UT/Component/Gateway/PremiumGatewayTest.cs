using EPayment.Base.BL.Component.Gateway;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.Base.BL.UT.Component.Gateway
{
	public class PremiumGatewayTest : UnitTest
	{
		private PremiumGateway premiumGateway;

		public PremiumGatewayTest()
		{
			premiumGateway = new PremiumGateway(BaseParameters)
			{
			};
		}

		[Fact]
		public void TestProcessPayment()
		{
			var result = premiumGateway.ProcessPayment(new Contract.DTO.PaymentDTO());
			result.Should().BeTrue();
		}
	}
}
