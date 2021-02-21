using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a validation class");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //CarValidator'un bir instance'ını oluştur (new lemek yerine)
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //CarValidator'un base type'ını bul -> (abstractValidator) -> onun da generic argumanlarından ilkini bul -> (Car)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //validation'ı yapılacak ilgili metdoun parametrelerini bul, validator'un tipine eşit olan parametreleri bul
            //invocation -> metod demek
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
