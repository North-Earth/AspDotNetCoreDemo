using System.Diagnostics;
using Learn.HtmlHelpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learn.HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var car = new Car { Id = 1, Mark = "Tesla", Model = "Model S" };
            return View(car);
        }

        public IActionResult Create(string state, string city, int number = 0)
        {
            return Content($"{state} - {city} - {number}");
        }

        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            return Content($"{car.Mark} - {car.Model}");
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
