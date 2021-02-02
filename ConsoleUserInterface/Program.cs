using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService(new InMemoryProductDal(new List<Car>{ 
                new Car{Id=1,BrandId=1,ColorId=3,ModelYear=2019,DailyPrice=50,Description="Volvo S40 2019 2000CC"},
                new Car{Id=2,BrandId=1,ColorId=4,ModelYear=2020,DailyPrice=80,Description="Volvo S80 2020 3000CC"},
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2021,DailyPrice=100,Description="BMW 5.20 2021 2000CC" }      
            }));

            productService.ListAll();

            Car car1 = new Car() {Id=4,BrandId=4,ColorId=5,ModelYear=2018,DailyPrice=170,Description="Opel Astra 2018 1.6 CDTI" };
            productService.Add(car1);

            foreach (var car in productService.GetById(4))
            {
                Console.WriteLine("Car GetById: " + car.Description);
            }
            
            Console.WriteLine("List all cars: "); 
            productService.ListAll();
            

        }
    }
}
