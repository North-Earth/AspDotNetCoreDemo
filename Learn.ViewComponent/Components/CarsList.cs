using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Learn.ViewComponent.Components
{
    public class CarsList : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private Dictionary<string, int> cars;
        /*
         * HttpContext: представляет контекст, который описывает полученный запрос, а также отправляемый ответ
         *ModelState: представляет состояние модели в виде объекта ModelStateDictionary
         *Request: возвращает контекст запроса в виде объекта HttpRequest
         *RouteData: возвращает данные маршрута
         *Url: представляет объект IUrlHelper, который используется для генерации адресов URL
         *User: представляет текущего пользователя в виде объкта IPrincipal
         *ViewBag: представляет динамический объект, который может использоваться для передачи данных в представление
         *ViewContext: описывает контекст главного представления, в котором вызывается компонент
         *ViewComponentContext: представляет объект ViewComponentContext, который инкапсулирует контекст компонента
         *ViewData: возвращает объект ViewDataDictionary, который применяется для передачи данных в представление
        */
        public CarsList()
        {
            cars = new Dictionary<string, int>
            {
                {"Mazda 3", 1025000 },
                {"Mazda 6", 1200000 },
                {"Toyota Camry New ", 1300000 },
                {"Honda CR-V ", 1600000 },
            };
        }

        public IViewComponentResult Invoke()
        {
            int maxPrice = cars.Max(x => x.Value);

            // если передан параметр id
            if (RouteData.Values.ContainsKey("id"))
                int.TryParse(RouteData.Values["id"]?.ToString(), out maxPrice);

            ViewBag.Cars = cars.Where(p => p.Value <= maxPrice).ToList();
            ViewData["Header"] = $"Автомобили с ценой от: {maxPrice.ToString("c")} и меньше";

            return View();
        }
    }
}
