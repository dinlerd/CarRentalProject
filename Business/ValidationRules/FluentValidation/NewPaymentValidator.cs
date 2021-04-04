using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class NewPaymentValidator : AbstractValidator<NewPayment>
    {
        public NewPaymentValidator()
        {
            RuleFor(p => p.NameSurname).NotEmpty();
            RuleFor(p => p.CardNo).NotEmpty();
            RuleFor(p => p.ExpirationDate).NotEmpty();
            RuleFor(p => p.Cvc).NotEmpty();
        }
    }
}
