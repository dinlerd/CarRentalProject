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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(CarColor color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
            //Console.WriteLine("carBrand: {0} added...", color.CarColorName);
        }

        public IResult Update(CarColor color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(CarColor color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
            //Console.WriteLine("carColor: {0} deleted...", color.CarColorName);
        }

        public IResult DeleteByColorId(int colorId)
        {
            _colorDal.DeleteByFilter(p=>p.CarColorId == colorId);
            return new SuccessResult(Messages.Deleted);
            //Console.WriteLine("carColor with Id: {0} deleted...", colorId);
        }

        public IDataResult<List<CarColor>> GetAll()
        {
            return new SuccessDataResult<List<CarColor>>(_colorDal.GetAll(),Messages.Listed);
        }

        public IDataResult<CarColor> GetByColorId(int colorId)
        {
            return new SuccessDataResult<CarColor>(_colorDal.Get(p=>p.CarColorId==colorId));
        }


    }
}
