using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Learn.Models.Models;
using Learn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Models.Controllers
{
    public class HomeController : Controller
    {
        private List<Company> companies;
        private List<Car> cars;

        public HomeController()
        {
            companies = new List<Company>
            {
                new Company { Id = 1, Name = "Mazda", Country = "Япония" },
                new Company { Id = 2, Name = "Toyota", Country = "Япония" },
                new Company { Id = 3, Name = "Ford", Country = "США" }
            };

            cars = new List<Car>
            {
                new Car { Id = 1, Manufacturer = companies[0], Model = "3", Price = 950000 },
                new Car { Id = 2, Manufacturer = companies[1], Model = "CX-5", Price = 1500000 },
                new Car { Id = 3, Manufacturer = companies[2], Model = "Focus", Price = 600000 },
            };
        }

        public IActionResult Index(int? companyId)
        {    
            // Формируем список компаний для передачи в представление.
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel { Id = c.Id, Name = c.Name })
                .ToList();

            // Добавляем на первое место.
            compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });

            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Cars = cars };

            // если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                ivm.Cars = cars.Where(p => p.Manufacturer.Id == companyId);

            return View(ivm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
