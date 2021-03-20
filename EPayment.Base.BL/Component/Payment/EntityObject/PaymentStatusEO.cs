using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.EntityObject
{
	public class PaymentStatusEO
	{
		[Key]
		public long PaymentStatusId { get; set; }
		public long PaymentId { get; set; }
		public string PatmentStatus { get; set; }

		[ForeignKey("PaymentId")]
		public PaymentEO PaymentEO { get; set; }
	}
}
