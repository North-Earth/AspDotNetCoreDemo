using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Routing.Controllers
{
    [Route("main")] //Префикс для всего контроллера.
    [Route("[controller]")] // Возможно указывать множественные маршруты.
    public class RoutingController : Controller
    {
        /// <summary>
        /// Получение информации о маршруте.
        /// </summary>
        /// <returns></returns>
        [Route("infopage")] // Явное указание маршрута 
        [Route("[action]")] // Второй маршрут.
        public IActionResult Index()
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            return Content($"controller: {controller} | action: {action}");
        }

        [Route("{id:int}/{name:maxlength(10)}")]
        public IActionResult Test(int id, string name)
        {
            return Content($" id={id} | name={name}");
        }

        // Опеределение пути через параметры.
        // /main/routing/exampleresult
        [Route("[controller]/[action]")]
        //[Route("[controller]")]
        //[Route("[action]")]
        //[Route("[controller]/[action]/{id?}")]
        public IActionResult ExampleResult()
        {
            return Content("Test text");
        }


    }
}