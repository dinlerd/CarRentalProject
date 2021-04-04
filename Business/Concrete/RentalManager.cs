﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);

            IResult result = BusinessRules.Run(CheckIfCarAvailable(rental.CarId,rental.CustomerId), FindeksScoreAvailabilityCheck(rental));

            if (result != null)
            {
                return result;
            }

            Console.WriteLine("Car is available.");
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeleteById(int Id)
        {
            _rentalDal.DeleteByFilter(r => r.Id == Id);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId), Messages.Listed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Rental> GetIdByRentalInfos(int carId, int customerId, DateTime rentDate, DateTime returnDate)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId
                                                                && r.CustomerId == customerId
                                                                && r.RentDate == rentDate
                                                                && r.ReturnDate == returnDate));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCarAvailable(int carId,int customerId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.CustomerId == customerId && r.ReturnDate == null);

            if (result.Count > 0)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            return new SuccessResult();
        }

        private IResult FindeksScoreAvailabilityCheck(Rental rental)
        {
            var result = _rentalDal.GetFindeksScores(rental.CarId, rental.CustomerId);

            if (result.CarMinFindeksScore <= result.CustomerFindeksScore)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.FindeksScoreIsNotEnough);
            }
        }
    }
}
