using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarColor:IEntity
    {
        public int CarColorId { get; set; }
        public string CarColorName { get; set; }

    }
}
