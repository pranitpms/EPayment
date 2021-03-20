using EPayment.Contract.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static EPayment.Contract.Common.PaymentEnumerations;

namespace EPayment.Contract.Common
{
	public class OperationOutcome : IOperationOutcome
	{
		public string OperationOutcomeCode { get; set; }
		public List<Issue> Issues { get; set; }

		public OperationOutcome()
		{
			Issues = new List<Issue>();
			OperationOutcomeCode = "Success";
		}

		public void AddError(int errorCode, string errorMessage, params object[] errorParams)
		{
			if (errorCode > 0)
			{
				OperationOutcomeCode = "Error";
				string additionalText = errorMessage;
				if (!string.IsNullOrEmpty(errorMessage) && errorParams != null)
					additionalText = string.Format(additionalText, errorParams);
				Issues.Add(new Issue { Code = errorCode, AdditionalText = additionalText, Severity = (int)ErrorType.ET_Error });
			}
		}
	}
}
