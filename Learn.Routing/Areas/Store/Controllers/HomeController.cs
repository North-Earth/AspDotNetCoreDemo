using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Routing.Areas.Store.Controllers
{
    [Area("Store")] //Определение принадлежности к области.
    public class HomeController : Controller
    {
        // Помимо маршрутизации в Starup
        // можно указать маршрут на прямую.
        // Параметр area указывает на текущую область.
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}