using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Contract.Common
{
	public class Issue
	{
		public Issue() : this(0, "") { }
		public Issue(int code, string additionalText) : this(code, additionalText, "") { }
		public Issue(int code, string additionalText, string description)
		{
			Code = code;
			AdditionalText = additionalText;
			Description = description;
		}


		public string AdditionalText { get; set; }
		public string Description { get; set; }
		public int Severity { get; set; }
		public int Code { get; set; }
	}
}
