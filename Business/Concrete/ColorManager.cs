using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(CarColor color)
        {
            _colorDal.Add(color);
            Console.WriteLine("carBrand: {0} added...", color.CarColorName);
        }

        public void Delete(CarColor color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("carColor: {0} deleted...", color.CarColorName);
        }

        public void DeleteByColorId(int colorId)
        {
            _colorDal.DeleteByFilter(p=>p.CarColorId == colorId);
            Console.WriteLine("carColor with Id: {0} deleted...", colorId);
        }

        public List<CarColor> GetAll()
        {
            return _colorDal.GetAll();
        }

        public CarColor GetByColorId(int colorId)
        {
            return _colorDal.Get(p=>p.CarColorId==colorId);
        }

        public void Update(CarColor color)
        {
            _colorDal.Update(color);
        }
    }
}
