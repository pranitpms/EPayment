using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Common
{
	public static class Common
	{
		public static class GateWayType
		{
			public static string Cheap = nameof(Cheap);
			public static string Expensive = nameof(Expensive);
		}

		public static class PaymentStatus
		{
			public static string Pending = nameof(Pending);
			public static string Processed = nameof(Processed);
			public static string Failed = nameof(Failed);
		}
	}
}
