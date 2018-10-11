using Microsoft.AspNetCore.Mvc;

namespace MvcAspDotNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}