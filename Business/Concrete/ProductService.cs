using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Car car)
        {
            _productDal.Add(car);
        }

        public void Delete(Car car)
        {
            _productDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Car> GetById(int SelectedId)
        {
            return _productDal.GetById(SelectedId);
        }

        public void ListAll()
        {
            foreach (var car in _productDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }

        public void Update(Car car)
        {
            _productDal.Update(car);
        }
    }
}
