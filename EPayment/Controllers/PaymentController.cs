using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPayment.API.Base;
using EPayment.Contract.DTO;
using EPayment.Contract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
	{
		private readonly IPaymentService PaymentService;
		public PaymentController(IOperationOutcome operationOutcome, IPaymentService paymentService) : base(operationOutcome)
		{
			PaymentService = paymentService;
		}

		[HttpPost]
        public ActionResult CreatePayment([FromBody] PaymentDTO paymentDTO)
        {
			return Result(PaymentService.ProcessPayment(paymentDTO));
		}
	}
}
