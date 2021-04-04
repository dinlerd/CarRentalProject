using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in filter==null ? context.Cars : context.Cars.Where(filter)
                             join cb in context.Brands
                             on c.BrandId equals cb.CarBrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.CarColorId
                             join carimage in context.CarImages
                             on c.Id equals carimage.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarDescription = c.Description,
                                 BrandName = cb.CarBrandName,
                                 ColorName = cc.CarColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 MinFindeksScore = c.MinFindeksScore,
                                 ImagePath = carimage.ImagePath,
                                 CarImageDate = carimage.Date
                             };
                return result.ToList();
            }

        }

        public CarDetailsDto GetCarDetail(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars.Where(c => c.Id == carId)
                             join cb in context.Brands
                             on c.BrandId equals cb.CarBrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.CarColorId
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarDescription = c.Description,
                                 BrandName = cb.CarBrandName,
                                 ColorName = cc.CarColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 MinFindeksScore = c.MinFindeksScore
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
