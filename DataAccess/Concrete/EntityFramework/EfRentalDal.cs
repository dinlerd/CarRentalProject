using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.Id
                             join u in context.Users on r.CustomerId equals u.Id
                             join cu in context.Customers on u.Id equals cu.UserId
                             select new RentalDetailDto { 
                                 Id=r.Id,
                                 CarId=c.Id,
                                 CarName=c.Description,
                                 CustomerId=cu.UserId,
                                 CustomerName=u.FirstName + " " + u.LastName,
                                 CompanyName=cu.CompanyName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
