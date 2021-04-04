using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeleteById(int Id)
        {
            _userDal.DeleteByFilter(p => p.Id == Id);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.Listed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }


        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userDal.Get(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.NotListed);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.Listed);
            }
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        //[SecuredOperation("admin,user.updateinfos")]
        //[ValidationAspect(typeof(UserValidator))]
        //[CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateSpecificInfos(User user)
        {
            User userInfos = GetById(user.Id).Data;

            userInfos.FirstName = user.FirstName;
            userInfos.LastName = user.LastName;
            userInfos.Email = user.Email;

            _userDal.Update(userInfos);

            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user),Messages.Listed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email),Messages.Listed);
        }
    }
}
