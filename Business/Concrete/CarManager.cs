using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //if (car.Description.Length < 2 || car.Description.StartsWith(" "))
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            //else if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);         
            //}

            //Loglama
            //cacheremove
            //performance
            //transaction
            //yetkilendirme
            //businesscodes

            //ValidationTool.Validate(new CarValidator(), car);


                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            
            
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        //[SecuredOperation("car.getall")]
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public void ListAll()
        {
            foreach (var car in _carDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
                Add(car);
                if (car.DailyPrice < 10)
                {
                    throw new Exception(Messages.NotAdded);
                }

                Add(car);

                return new SuccessResult(Messages.AddTransactionalTest);

        }
    }
}
