using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcAspDotNetCoreDemo.Models;

namespace MvcAspDotNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        CarContext db;

        public HomeController(CarContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return $"{order.User}, спасибо за покупку!";
        }
    }
}