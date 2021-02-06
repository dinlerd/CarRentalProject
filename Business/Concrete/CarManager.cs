using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2 || car.Description.StartsWith(" "))
            {
                Console.WriteLine("Please Enter a name bigger than 2 characters and not whitespace");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Please enter a Dailyprice bigger than 0");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine(car.Description + " added successfully!");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Description + " deleted!");
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int Id)
        {
            return _carDal.GetAll(p => p.Id == Id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c=>c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void ListAll()
        {
            foreach (var car in _carDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
