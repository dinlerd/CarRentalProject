//using Business.Abstract;
//using Entities.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CarImagesController : ControllerBase
//    {
//        ICarImageService _carImageService;

//        protected readonly string imageDirectory = @"wwwroot\CarImages";

//        public CarImagesController(ICarImageService carImageService)
//        {
//            _carImageService = carImageService;
//        }

//        [HttpGet("getall")]
//        public IActionResult GetAll()
//        {
//            var result = _carImageService.GetAll();
//            if (result.Success)
//            {
//                return Ok(result);
//            }

//            return BadRequest(result);
//        }

//        [HttpPost("Add")]
//        public IActionResult Add(int carId, IFormFile imageFile)
//        {
//            try
//            {
//                string fileName;
//                if (imageFile != null)
//                {
//                    fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(imageFile.FileName);
//                }
//                    fileName = "togg.png";
//                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory, fileName);
                
//                    var result = _carImageService.Add(new CarImage() 
//                    { 
//                        CarId = carId, 
//                        Date = DateTime.Now, 
//                        ImagePath = filePath 
//                    });

//                    if (result.Success && imageFile != null)
//                    {
//                        using (var fileStream = new FileStream(filePath, FileMode.Create))
//                        {
//                            imageFile.CopyTo(fileStream);
//                        }

//                        return Ok(result);
//                    }

//                    return BadRequest(result);
                


//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }

//        [HttpPost("Update")]
//        public IActionResult Update(int id, IFormFile imageFile)
//        {

//            if (imageFile != null && imageFile.Length > 0)
//            {
//                var image = _carImageService.GetById(id).Data;

//                string fileName = image.ImagePath;
//                string filePath = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory, fileName);
//                System.IO.File.Delete(filePath);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    imageFile.CopyTo(fileStream);
//                }

//                image.Date = DateTime.Now;
//                var result = _carImageService.Update(image);
//                if (result.Success)
//                {
//                    return Ok(result);
//                }
                    
//                return BadRequest(result);
//            }

//            return BadRequest();
//        }

//        [HttpPost("Delete")]
//        public IActionResult Delete(int id)
//        {
//            var image = _carImageService.GetById(id).Data;

//            string fileName = image.ImagePath;
//            string filePath = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory, fileName);
//            System.IO.File.Delete(filePath);

//            var result = _carImageService.Delete(image);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
                
//            return BadRequest(result);
//        }

        //[HttpPost("add")]

        //public IActionResult Add(CarImage carImage)
        //{
        //    var result = _carImageService.Add(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        //[HttpPost("update")]

        //public IActionResult Update(CarImage carImage)
        //{
        //    var result = _carImageService.Update(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        //[HttpPost("delete")]

        //public IActionResult Delete(CarImage carImage)
        //{
        //    var result = _carImageService.Delete(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
//    }
//}
