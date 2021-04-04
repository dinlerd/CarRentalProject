﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailImageDto:IDto
    {
        public int CarId { get; set; }
        public string CarDescription { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string ImagePath { get; set; }
        public DateTime CarImageDate { get; set; }
        public int MinFindeksScore { get; set; }
    }
}
