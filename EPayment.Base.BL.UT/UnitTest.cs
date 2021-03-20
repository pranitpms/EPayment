using AutoMapper;
using EPayment.Base.BL.Common;
using EPayment.Base.BL.Component.Payment.Configurations;
using EPayment.Contract.Common;
using EPayment.Contract.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayment.Base.BL.UT
{
	public abstract class UnitTest
	{
		private IOperationOutcome operationOutcomeMock;
		private IMapper mapperMock;

		private BaseParameter baseParmeters = null;

		public BaseParameter BaseParameters
		{
			get { return baseParmeters; }
		}

		public UnitTest()
		{
			baseParmeters = GetBaseParams();
		}

		private BaseParameter GetBaseParams()
		{
			var m = new MapperConfiguration(c => { c.AddProfile(new PaymentProfile()); });
			operationOutcomeMock = new OperationOutcome();
			mapperMock = m.CreateMapper();
			baseParmeters = new BaseParameter(operationOutcomeMock, mapperMock);
			return baseParmeters;
		}
	}
}
