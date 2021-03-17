//using Core.Utilities.Results;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Core.Utilities.Helpers
//{
//    public class FileHelper
//    {
//        public static string Add(IFormFile imageFile)
//        {
//                var result = newPath(imageFile);

//                if (imageFile.Length > 0 && imageFile != null)
//                {
//                    using (var fileStream = new FileStream(result, FileMode.Create))
//                    {
//                        imageFile.CopyTo(fileStream);
//                    }
//                }

//            var sourcepath = Path.GetTempFileName();
          
//            var result = newPath(file);
//            File.Move(sourcepath, result);
//            return result;
//        }
//        public static IResult Delete(string path)
//        {
//            try
//            {
//                File.Delete(path);
//            }
//            catch (Exception exception)
//            {
//                return new ErrorResult(exception.Message);
//            }

//            return new SuccessResult();
//        }
//        public static string Update(string sourcePath, IFormFile file)
//        {
//            var result = newPath(file);
//            if (sourcePath.Length > 0)
//            {
//                using (var stream = new FileStream(result, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }
//            }
//            File.Delete(sourcePath);
//            return result;
//        }
//        public static string newPath(IFormFile imageFile)
//        {
//            Path.GetExtension(imageFile.FileName)

//            //string imagePath = Environment.CurrentDirectory + @"\CarImages";
            
//            string imageDirectory = @"wwwroot\CarImages";
//            var newPath = Guid.NewGuid().ToString("N") + Path.GetExtension(imageFile.FileName);
//            string resultPath = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory, newPath);
            
//            //string resultPath = $@"{imagePath}\{newPath}";
//            return resultPath;
//        }


//    }
//}
