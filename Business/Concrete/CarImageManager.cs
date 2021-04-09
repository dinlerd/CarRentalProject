using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[SecuredOperation("carImages.add,admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            if(file == null)
            {
                carImage.ImagePath = @"/uploads/togg.jpg";
            }
            else
            {
                string[] path = FileHelper.Add(file).Split('\\');
                string newImagePath = path[path.Length - 2].ToString();
                newImagePath = "/" + newImagePath + "/" + path[path.Length - 1].ToString();
                carImage.ImagePath = newImagePath;
            }

            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carImages.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carImages.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 20)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\uploads\togg.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }



    }
}



//using Business.Abstract;
//using Business.Constants;
//using Business.ValidationRules.FluentValidation;
//using Core.Aspects.Autofac.Validation;
//using Core.Utilities.Business;
//using Core.Utilities.Results;
//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Business.Concrete
//{
//    public class CarImageManager : ICarImageService
//    {
//        ICarImageDal _carImageDal;
//        ICarService _carService;

//        public CarImageManager(ICarImageDal carImageDal,ICarService carServiceDal)
//        {
//            _carImageDal = carImageDal;
//            _carService = carServiceDal;

//        }

//        [ValidationAspect(typeof(CarImageValidator))]
//        public IResult Add(CarImage carImage)
//        {
//            IResult result = BusinessRules.Run(CheckIfCarExists(carImage.CarId), CheckCarImageLimit(carImage.CarId));

//            if (result != null)
//            {
//                return result;
//            }
//                    _carImageDal.Add(carImage);
//                    return new SuccessResult(Messages.Added);

//        }

//        public IResult Delete(CarImage carImage)
//        {
//            _carImageDal.Delete(carImage);
//            return new SuccessResult(Messages.Deleted);
//        }

//        public IDataResult<List<CarImage>> GetAll()
//        {
//            //var result = _carImageDal.GetAll(c => c.ImagePath == null);
//            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.Listed);
//        }

//        public IDataResult<CarImage> GetById(int id)
//        {
//            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
//        }

//        public IDataResult<List<CarImage>> GetCarImagesById(int carId)
//        {
//            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.Listed);
//        }

//        public IResult Update(CarImage carImage)
//        {
//            _carImageDal.Update(carImage);
//            return new SuccessResult(Messages.Updated);
//        }

//        private IResult CheckCarImageLimit(int carId)
//        {
//            var result = _carImageDal.GetAll(c=>c.CarId==carId);
//            if (result.Count>4)
//            {
//                return new ErrorResult(Messages.CarImageLimitExceeded);
//            }

//            return new SuccessResult();

//        }

//        private IResult CheckIfCarExists(int carId)
//        {
//            var result = _carService.GetById(carId).Success;
//            if (result)
//            {
//                return new SuccessResult();
//            }
//            return new ErrorResult(Messages.CarNotExists);
//        }
//    }
//}
