using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            //CarTest();

            CarBrandTest();

            //GetCarDetailsTest();

            //CarColorTest();

        }

        private static void CarColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //CarColor carColor1 = new CarColor() { CarColorName = "Green" };
            //colorManager.Add(carColor1);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id: " + color.CarColorId + " Color Name: " + color.CarColorName);
            }

            //colorManager.Delete(new CarColor {CarColorId=1003, CarColorName="Green" });
            //colorManager.Delete(new CarColor { CarColorId = 2004, CarColorName = "Green" });
            //colorManager.DeleteByColorId(3003);
            Console.WriteLine("---------------------------------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id: " + color.CarColorId + " Color Name: " + color.CarColorName);
            }
            //Console.WriteLine("Get by ColorId: " + colorManager.GetByColorId(3));
            Console.WriteLine("Color id: {0}", colorManager.GetByColorId(2).CarColorName); 
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarDescription + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }

        private static void InMemoryTest()
        {
            CarManager productService = new CarManager(new InMemoryCarDal(new List<Car>{
                new Car{Id=1,BrandId=1,ColorId=3,ModelYear=2019,DailyPrice=50,Description="Volvo S40 2019 2000CC"},
                new Car{Id=2,BrandId=1,ColorId=4,ModelYear=2020,DailyPrice=80,Description="Volvo S80 2020 3000CC"},
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2021,DailyPrice=100,Description="BMW 5.20 2021 2000CC" }
            }));

            productService.ListAll();

            Car car1 = new Car() { Id = 4, BrandId = 4, ColorId = 5, ModelYear = 2018, DailyPrice = 170, Description = "Opel Astra 2018 1.6 CDTI" };
            productService.Add(car1);

            foreach (var car in productService.GetAll())
            {
                Console.WriteLine("Car GetById: " + car.Description);
            }

            Console.WriteLine("List all cars: ");
            productService.ListAll();
        }

        private static void CarBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarBrand carBrand1 = new CarBrand() { CarBrandName = "OPEL" };
            brandManager.Add(carBrand1);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} / {1} ", brand.CarBrandId, brand.CarBrandName);
            }

            brandManager.Delete(carBrand1);
            Console.WriteLine("Get By Brand Id: {0} ", brandManager.GetByBrandId(2).CarBrandName); 
        }

        private static void CarTest()
        {
            CarManager carService = new CarManager(new EfCarDal());
            Car car1 = new Car() { BrandId = 1003, ColorId = 3, ModelYear = 2017, DailyPrice = 10000, Description = "Opel Corsa 1.3 CDTI" };
            carService.Add(car1);
            //carService.Delete(car1);


            Console.WriteLine("------------------------");
            Console.WriteLine("All Cars: ");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Cars ByBrandId: ");
            foreach (var car in carService.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            carService.Delete(car1);
        }
    }
}
