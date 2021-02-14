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

            //CarBrandTest();

            //GetCarDetailsTest();

            //CarColorTest();

            //UserTest();

            //CustomerTest();

            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.DeleteById(1002);

            rentalManager.Update(new Rental
            {
                Id=1007,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 10),
                ReturnDate = DateTime.Now 

            });

            rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 13),
                ReturnDate = null

            });

            var rentallist = rentalManager.GetAll();
            if (rentallist.Success)
            {
                foreach (var rental in rentallist.Data)
                {
                    Console.WriteLine("Rentals, CarId: {0} CustomerId: {1} RentDate: {2} ReturnDate: {3} ",
                        rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
                    Console.WriteLine(rentallist.Message);
                }
            }
            else
            {
                Console.WriteLine(rentallist.Message);
            }

            foreach (var detail in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Rental Details:\n Id: {0}\n CarId: {1}\n CarName: {2}\n " +
                    "CustomerId: {3}\n CustomerName: {4}\n CompanyName: {5}\n RentDate: {6}\n ReturnDate: {7}",
                    detail.Id,detail.CarId,detail.CarName,detail.CustomerId,
                    detail.CustomerName,detail.CompanyName,detail.RentDate,detail.ReturnDate);
            }
            
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            /*customerManager.Add(new Customer { 
                UserId = 1,
                CompanyName = "Garanti BBVA"
            });*/
            /*customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "Company1"
            });*/
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("CompanyName: {0} UserId: {1} CustomerId: {2} ", customer.CompanyName, customer.UserId, customer.Id);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            /*userManager.Add(new User
            {
                FirstName = "isim1",
                LastName = "soyisim1",
                Email = "ss1@email.com",
                Password = "12345"
            });*/
            //userManager.DeleteById(1002);

            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("User: {0} {1}   UserId: {2} ", user.FirstName, user.LastName,user.Id);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //CarColor carColor1 = new CarColor() { CarColorName = "Green" };
            //colorManager.Add(carColor1);

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Color Id: " + color.CarColorId + " Color Name: " + color.CarColorName);
            }

            //colorManager.Delete(new CarColor {CarColorId=1003, CarColorName="Green" });
            //colorManager.Delete(new CarColor { CarColorId = 2004, CarColorName = "Green" });
            //colorManager.DeleteByColorId(3003);
            Console.WriteLine("---------------------------------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Color Id: " + color.CarColorId + " Color Name: " + color.CarColorName);
            }
            //Console.WriteLine("Get by ColorId: " + colorManager.GetByColorId(3));
            Console.WriteLine("Color id: {0}", colorManager.GetByColorId(2).Data.CarColorId); 
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
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

            foreach (var car in productService.GetAll().Data)
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

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1} ", brand.CarBrandId, brand.CarBrandName);
            }

            brandManager.Delete(carBrand1);
            Console.WriteLine("Get By Brand Id: {0} ", brandManager.GetByBrandId(2).Data.CarBrandName); 
        }

        private static void CarTest()
        {
            CarManager carService = new CarManager(new EfCarDal());
            Car car1 = new Car() { BrandId = 1003, ColorId = 3, ModelYear = 2017, DailyPrice = 10000, Description = "Opel Corsa 1.3 CDTI" };
            carService.Add(car1);
            //carService.Delete(car1);


            Console.WriteLine("------------------------");
            Console.WriteLine("All Cars: ");
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Cars ByBrandId: ");
            foreach (var car in carService.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Description);
            }
            carService.Delete(car1);
        }
    }
}
