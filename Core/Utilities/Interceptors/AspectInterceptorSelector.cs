using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //çalıştırılmak istenen Metodun üstüne bakar, oradaki intercepter(aspect) leri bulur ve çalıştırır
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            //tüm metodlarra ve bundan sonra eklenecek olanları da loglamak amacıyla, loglama altyapısını oluşturduktan sonra burada aktive ediyoruz
            //classAttributes.Add(new PerformanceAspect(5));
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }


}
