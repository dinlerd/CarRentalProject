using Business.Abstract;
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

        public void Add(CarBrand carBrand)
        {
            _ibrandDal.Add(carBrand);
            Console.WriteLine("carBrand: {0} added...",carBrand.CarBrandName);
        }

        public void Delete(CarBrand carBrand)
        {
            _ibrandDal.Delete(carBrand);
            Console.WriteLine("carBrand: {0} deleted...", carBrand.CarBrandName);
        }

        public List<CarBrand> GetAll()
        {
            return _ibrandDal.GetAll();
        }
    }
}
