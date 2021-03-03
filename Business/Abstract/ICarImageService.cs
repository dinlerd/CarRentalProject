using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        //IResult Add(CarImage carImage);
        //IResult Delete(CarImage carImage);
        //IResult Update(CarImage carImage);
        //IDataResult<List<CarImage>> GetAll();
        //IDataResult<List<CarImage>> GetCarImagesById(int id);
        //IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile imageFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile imageFle, CarImage carImage);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}
