using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Common
{
	public class ApiActionResult
	{
		public dynamic Data { get; set; }
		public string Status { get; set; }
		public List<Issue> Issues { get; set; }
	}
}
