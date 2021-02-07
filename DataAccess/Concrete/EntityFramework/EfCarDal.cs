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
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join cb in context.Brands
                             on c.BrandId equals cb.CarBrandId
                             join cc in context.Colors
                             on c.ColorId equals cc.CarColorId
                             select new CarDetailDto
                             {
                                 CarId=c.Id,
                                 CarDescription = c.Description,
                                 BrandName = cb.CarBrandName,
                                 ColorName = cc.CarColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
            

        }
    }
}
