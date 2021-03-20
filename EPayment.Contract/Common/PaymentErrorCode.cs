using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Common
{
	public enum PaymentErrorCode : int
	{
		Card_Number_Is_Empty = 1001,
		Card_Invalid_Number = 1002,
		Card_Holder_Name_Empty = 1003,
		Card_Expiration_Date_Empty = 1003,
		Card_Expiration_Date_Invalid = 1004,
		Card_Security_Code_Invalid = 1005,
		Payment_Amount_Empty = 1007,
		Payment_Amount_Negative = 1008,
		Invalid_Request = 9999,
		Internal_Error = 500
	}
}
