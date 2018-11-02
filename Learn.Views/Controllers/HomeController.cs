using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Learn.Views.Models;

namespace Learn.Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Явно указываем путь к странице представления.
            //return View("~/Views/Hello.cshtml");

            return View();
        }

        public ActionResult GetMessage()
        {
            // PartialViewResult отвечает за рендаринг частичных представлений.
            return PartialView("_GetMessage");
        }

        public IActionResult About()
        {
            // ViewData Передача знаний в представление по ключу.
            ViewData["Title"] = "Hello!";
            ViewData["Message"] = "ASP.NET Core";

            // ViewBag позволяет передавать сложные объекты.
            ViewBag.MessageBag = "I'm Bag message";
            ViewBag.Cars = new List<string> { "Honda", "Toyota", "Nissan", "Mazda" };

            //Передача черезе модель представления.
            var Cars = new List<string> { "Honda", "Toyota", "Nissan", "Mazda" };

            return View(Cars);
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
