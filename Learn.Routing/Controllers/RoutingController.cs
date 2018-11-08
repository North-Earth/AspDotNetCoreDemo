using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Routing.Controllers
{
    public class RoutingController : Controller
    {
        /// <summary>
        /// Получение информации о маршруте.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            return Content($"controller: {controller} | action: {action}");
        }
    }
}