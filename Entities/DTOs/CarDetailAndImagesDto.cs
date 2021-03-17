using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDetailAndImagesDto : IDto
    {
        public CarDetailsDto Car { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
