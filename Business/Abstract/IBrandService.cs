using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(CarBrand carBrand);
        void Update(CarBrand carBrand);
        void Delete(CarBrand carBrand);
        List<CarBrand> GetAll();
        CarBrand GetByBrandId(int brandId);


    }
}
