﻿using Core.DataAccess.EntityFramework;
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
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             //join cu in context.Customers on u.Id equals cu.UserId
                             join br in context.Brands on c.BrandId equals br.CarBrandId
                             join cl in context.Colors on c.ColorId equals cl.CarColorId
                             select new RentalDetailDto {
                                 Id = r.Id,
                                 CarId = c.Id,
                                 BrandName = br.CarBrandName,
                                 ColorName = cl.CarColorName,
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

        public FindeksScoreDto GetFindeksScores(int carId, int customerId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars.Where(c => c.Id == carId)
                             from cu in context.Customers.Where(cu => cu.Id == customerId)
                             select new FindeksScoreDto
                             {
                                 CarMinFindeksScore = c.MinFindeksScore,
                                 CustomerFindeksScore = cu.FindeksScore,
                             };

                return result.SingleOrDefault();
            };
        }
    }
}
