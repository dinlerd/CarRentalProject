using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            //RuleFor(i => i.ImagePath).NotEmpty();
            //RuleFor(i => i.ImagePath).NotNull();
            RuleFor(i => i.CarId).NotEmpty();
            RuleFor(c => c.CarId).NotNull();

        } 
    }
}
