using AutoMapper;
using EPayment.Base.BL.Component.Payment.EntityObject;
using EPayment.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.Component.Payment.Configurations
{
	public class PaymentProfile : Profile
	{
		public PaymentProfile()
		{
			CreateMap<PaymentEO, PaymentDTO>();
			CreateMap<PaymentDTO, PaymentEO>();
		}
	}
}
