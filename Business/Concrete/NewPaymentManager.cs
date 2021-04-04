using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class NewPaymentManager : INewPaymentService
    {


        INewPaymentDal _newPaymentDal;


        public NewPaymentManager(INewPaymentDal newPaymentDal)
        {
            _newPaymentDal = newPaymentDal;
        }


        //[ValidationAspect(typeof(NewPaymentValidator))]
        public IResult Add(NewPayment newPayment)
        {
            _newPaymentDal.Add(newPayment);

            return new SuccessResult(Messages.Added);
        }


    }
}
