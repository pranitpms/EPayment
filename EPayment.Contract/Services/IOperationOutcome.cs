using EPayment.Contract.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Services
{
	public interface IOperationOutcome
	{
		string OperationOutcomeCode { get; set; }
		List<Issue> Issues { get; set; }
		void AddError(int errorCode, string errorMessage, params object[] errorParams);
	}
}
