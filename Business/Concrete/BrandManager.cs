using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _ibrandDal;

        public BrandManager(IBrandDal ibrandDal)
        {
            _ibrandDal = ibrandDal;
        }

        public IResult Add(CarBrand carBrand)
        {
            _ibrandDal.Add(carBrand);
            return new SuccessResult(Messages.Added);
            
        }

        public IResult Update(CarBrand carBrand)
        {
            _ibrandDal.Update(carBrand);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(CarBrand carBrand)
        {
            _ibrandDal.Delete(carBrand);
            return new SuccessResult(Messages.Deleted);
            //Console.WriteLine("carBrand: {0} deleted...", carBrand.CarBrandName);
        }

        public IDataResult<List<CarBrand>> GetAll()
        {
            return new SuccessDataResult<List<CarBrand>>(_ibrandDal.GetAll(),Messages.Listed);
        }

        public IDataResult<CarBrand> GetByBrandId(int brandID)
        {
            return new SuccessDataResult<CarBrand>(_ibrandDal.Get(p => p.CarBrandId == brandID));
        }


    }
}
