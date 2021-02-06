using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(CarBrand entity)
        {
            using (CarContext context = new CarContext())
            {
                //context.CarBrands.Add(entity);
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarBrand entity)
        {
            using (CarContext context = new CarContext())
            {
                context.CarBrands.Remove(entity);
                context.SaveChanges();
            }
        }

        public CarBrand Get(Expression<Func<CarBrand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarBrand> GetAll(Expression<Func<CarBrand, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null ? context.CarBrands.ToList() : context.Set<CarBrand>().Where(filter).ToList();
            }
        }

        public void Update(CarBrand entity)
        {
            throw new NotImplementedException();
        }
    }
}
