using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Common
{
	public class PaymentEnumerations
	{
		public enum ErrorType : int
		{
			ET_Error = 1,
			ET_Warning = 2,
			ET_Info = 3,
		}
	}
}
