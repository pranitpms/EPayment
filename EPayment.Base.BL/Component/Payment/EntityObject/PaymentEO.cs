using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.EntityObject
{
	public class PaymentEO
	{
		[Key]
		public long PaymentId { get; set; }
		public string CreditCardNumber { get; set; }
		public string CardHolder { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int? SecurityCode { get; set; }
		public decimal Amount { get; set; }
		public DateTime? PaymentDate { get; set; }
	    public virtual PaymentStatusEO PaymentStatus { get; set; }
	}
}
