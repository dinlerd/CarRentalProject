using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarContext>, ICustomerDal
    {
        public UserWhoIsCustomerDto GetCustomerIdOfUser(string email)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             where u.Email == email
                             select new UserWhoIsCustomerDto
                             {
                                 userId = u.Id,
                                 email = u.Email,
                                 customerId = c.Id,
                                 FindeksScore = c.FindeksScore,
                                 CompanyName = c.CompanyName
                             };

                return result.SingleOrDefault();
            };
        }
    }
}
