using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Car> GetAll();
        void ListAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetById(int SelectedId);

    }
}
