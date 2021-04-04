using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {


        ICreditCardDal _creditCardDal;


        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }


        //[SecuredOperation("admin,creditcard.add")]
        //[ValidationAspect(typeof(CreditCardValidator))]
        //[CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckCardExists(creditCard.CustomerId, creditCard.CardNo));

            if (result != null)
            {
                return result;
            }

            _creditCardDal.Add(creditCard);

            return new SuccessResult(Messages.Added);
        }


        //[SecuredOperation("admin,creditcard.delete")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);

            return new SuccessResult(Messages.Deleted);
        }


        //[SecuredOperation("admin,creditcard.update")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);

            return new SuccessResult(Messages.Updated);
        }


        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }


        // Business Rules Methods
        private IResult CheckCardExists(int customerId, string cardNo)
        {
            var result = _creditCardDal.Get(c => c.CardNo == cardNo
                                            && c.CustomerId == customerId);

            if (result != null)
            {
                return new ErrorResult(Messages.CardExists);
            }
            return new SuccessResult();
        }


    }
}
