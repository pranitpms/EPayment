using EPayment.Base.BL.Common;
using EPayment.Base.BL.Component.Payment.Interfaces;
using EPayment.Contract.Common;
using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPayment.Base.BL.Component.Payment
{
	public class PaymentValidator : BaseComponent, IPaymentValidator
	{
		public PaymentValidator(IBaseParameter baseParameter) : base(baseParameter)
		{ }

		public bool Validate(PaymentDTO paymentDTO)
		{
			bool isValid = false;
			if (paymentDTO != null)
			{
				isValid = IsValidCardNumber(paymentDTO.CreditCardNumber);
				isValid = IsValidateCardHolder(paymentDTO.CardHolder) && isValid;
				isValid = IsValidateExpirationDate(paymentDTO.ExpirationDate) && isValid;
				isValid = IsValidateSecurityCode(paymentDTO.SecurityCode) && isValid;
				isValid = IsValidateAmount(paymentDTO.Amount) && isValid;
			}
			else
				AddError(PaymentErrorCode.Invalid_Request, "Invalid Request");
			return isValid;
		}

		#region Private Method
		private bool IsValidCardNumber(string cardNumber)
		{
			bool isValid = false;
			if (string.IsNullOrEmpty(cardNumber))
				AddError(PaymentErrorCode.Card_Number_Is_Empty, "CreditCard Number is Mandatory");
			else
			{
				string masterCard = "^(51|52|53|54|55)";
				string visaCard = "^(4)";
				if(Regex.IsMatch(cardNumber, masterCard))
					isValid = cardNumber.Length == 16;
				else if(Regex.IsMatch(cardNumber, visaCard))
					isValid = cardNumber.Length == 13 || cardNumber.Length == 16;
				if(!isValid)
					AddError(PaymentErrorCode.Card_Invalid_Number, "CreditCard Number is Invalid");
			}
			return isValid;
		}

		private bool IsValidateCardHolder (string name)
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(name))
			{
				isValid = false;
				AddError(PaymentErrorCode.Card_Holder_Name_Empty, "Card Holder Name is Mandatory");
			}
			return isValid;
		}

		private bool IsValidateExpirationDate(DateTime expirationDate)
		{
			bool isValid = false;
			if (expirationDate != DateTime.MinValue)
			{
				isValid = expirationDate > DateTime.Now;
				if(!isValid)
					AddError(PaymentErrorCode.Card_Expiration_Date_Empty, "Invalid Expiration Date");
			}
			else
				AddError(PaymentErrorCode.Card_Expiration_Date_Empty, "Expiration Date is Mandatory");
			return isValid;
		}

		private bool IsValidateSecurityCode(string securityCode)
		{
			bool isValid = true;
			if (!string.IsNullOrEmpty(securityCode))
			{
				isValid = securityCode.Length == 3;
				if(!isValid)
					AddError(PaymentErrorCode.Card_Security_Code_Invalid, "Security Code should be 3 digit");
			}
			return isValid;
		}

		private bool IsValidateAmount(decimal amount)
		{
			bool isValid = false;
			if (amount != decimal.MinValue)
			{
				isValid = amount > 0;
				if (!isValid)
					AddError(PaymentErrorCode.Payment_Amount_Negative, "Amount should be Non - Negative");
			}
			else
				AddError(PaymentErrorCode.Payment_Amount_Empty, "Amount is mandatory");
			return isValid;
		}
		#endregion
	}
}
