using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<CarBrand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.CarBrandName).MinimumLength(2);
        }
    }
}
