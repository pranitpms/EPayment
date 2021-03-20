using EPayment.API.Controllers;
using EPayment.Contract.Common;
using EPayment.Contract.DTO;
using EPayment.Contract.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EPayment.API.Test.Controller
{
	public class PaymentControllerTest
	{
		private Mock<IPaymentService> paymentServiceMock;
		private PaymentController paymentController;
		public PaymentControllerTest()
		{
			IOperationOutcome operationOutcome = new OperationOutcome();
			paymentServiceMock = new Mock<IPaymentService>();
			paymentController = new PaymentController(operationOutcome, paymentServiceMock.Object);
		}

		#region Facts
		[Fact(DisplayName = "Process Payment Null Request")]
		public void TestCreatePayment_NullRequest()
		{
			SetUpGatewayComponent(false);
			var result = paymentController.CreatePayment(null);
			var objResult = Assert.IsType<BadRequestObjectResult>(result);
			ApiActionResult apiActionResult =  Assert.IsType<ApiActionResult>(objResult.Value);
			((bool)apiActionResult.Data).Should().BeFalse();
		}

		[Xunit.Fact(DisplayName = "Process Payment Invalid Request")]
		public void TestCreatePayment_InvalidRequest()
		{
			SetUpGatewayComponent(false);
			var result = paymentController.CreatePayment(new PaymentDTO());
			var objResult = Assert.IsType<BadRequestObjectResult>(result);
			ApiActionResult apiActionResult = Assert.IsType<ApiActionResult>(objResult.Value);
			((bool)apiActionResult.Data).Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return false")]
		public void TestCreatePayment_ReturnsFalse()
		{
			SetUpGatewayComponent(false);
			var result = paymentController.CreatePayment(new PaymentDTO());
			var objResult = Assert.IsType<BadRequestObjectResult>(result);
			ApiActionResult apiActionResult = Assert.IsType<ApiActionResult>(objResult.Value);
			((bool)apiActionResult.Data).Should().BeFalse();
		}

		[Fact(DisplayName = "Process Payment return true")]
		public void TestCreatePayment_ReturnsTrue()
		{
			SetUpGatewayComponent(true);
			var result = paymentController.CreatePayment(new PaymentDTO());
			var objResult = Assert.IsType<OkObjectResult>(result);
			ApiActionResult apiActionResult = Assert.IsType<ApiActionResult>(objResult.Value);
			((bool)apiActionResult.Data).Should().BeTrue();
		}

		#endregion

		#region Private Method
		private void SetUpGatewayComponent(bool isProcess)
		{
			paymentServiceMock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDTO>())).Returns(isProcess);
			if (!isProcess)
			{
				paymentController.OperationOutcome.Issues = new List<Issue>
				{
					new Issue(400,"InvalidRequest")
				};
			}
		}
		#endregion
	}
}
