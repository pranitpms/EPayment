using AutoMapper;
using EPayment.Contract.Common;
using EPayment.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPayment.API.Base
{
	public abstract class BaseController : ControllerBase
	{
		public IOperationOutcome OperationOutcome { get; set; }

		public BaseController(IOperationOutcome operationOutcome)
		{
			OperationOutcome = operationOutcome;
		}

		protected internal ActionResult Result<T>(T transferData)
		{
			List<Issue> issues = null;
			if (OperationOutcome.Issues != null && OperationOutcome.Issues.Count > 0)
			{
				issues = OperationOutcome.Issues.Where(x => x.Code == (int)PaymentErrorCode.Internal_Error).ToList();
				if (issues != null && issues.Count > 0)
					return StatusCode((int)PaymentErrorCode.Internal_Error,  CreateApiActionResult(transferData, issues));
				else 
				{
					issues = OperationOutcome.Issues.Where(x => x.Code != (int)PaymentErrorCode.Internal_Error).ToList();
					if (issues != null && issues.Count > 0)
						return BadRequest(CreateApiActionResult(transferData, issues));
				}
			}
			return this.Ok(CreateApiActionResult(transferData,  issues));
		}

		private ApiActionResult CreateApiActionResult(dynamic data, List<Issue> issues)
		{
			return new ApiActionResult
			{
				Data = data,
				Status = OperationOutcome.OperationOutcomeCode,
				Issues = issues
			};
		}
	}
}
