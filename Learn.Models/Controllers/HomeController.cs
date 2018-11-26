using System.Collections.Generic;
using System.Diagnostics;
using Learn.Models.Models;
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

        public IActionResult Index()
        {
            return View(cars);
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
