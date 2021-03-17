using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(CarBrand carBrand);
        IResult Update(CarBrand carBrand);
        IResult Delete(CarBrand carBrand);
        IDataResult<List<CarBrand>> GetAll();
        IDataResult<CarBrand> GetByBrandId(int brandId);
        IResult DeleteById(int Id);
    }
}
