using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers.Controllers
{
    public class FilesController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;

        public FilesController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        // Отправка физического файла.
        public IActionResult GetPhysicalFile()
        {
            // Путь к файлу
            string filePath = Path.Combine(_appEnvironment.ContentRootPath, "Files/Dictionary.xlsx");
            // Тип файла - content-type
            string fileType = "application/xlsx";
            // Имя файла - необязательно
            string fileName = "Dictionary.xlsx";
            return PhysicalFile(filePath, fileType, fileName);
        }

        // Отправка массива байтов
        public FileResult GetBytes()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Dictionary.xlsx");
            byte[] array = System.IO.File.ReadAllBytes(path);
            string fileType = "application/xlsx";
            string fileName = "Dictionary.xlsx";
            return File(array, fileType, fileName);
        }

        // Отправка потока
        public FileResult GetStream()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Dictionary.xlsx");
            FileStream fs = new FileStream(path, FileMode.Open);
            string fileType = "application/xlsx";
            string fileName = "Dictionary.xlsx";
            return File(fs, fileType, fileName);
        }

        // Отправка файла из wwwroot
        public VirtualFileResult GetVirtualFile()
        {
            var filepath = Path.Combine("~/Files", "Test.bmp");
            return File(filepath, "application/bmp", "Test.bmp");
        }
    }
}