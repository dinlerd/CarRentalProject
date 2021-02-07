using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(CarColor color);
        void Update(CarColor color);
        void Delete(CarColor color);
        void DeleteByColorId(int colorId);
        List<CarColor> GetAll();
        CarColor GetByColorId(int colorId);
    }
}
