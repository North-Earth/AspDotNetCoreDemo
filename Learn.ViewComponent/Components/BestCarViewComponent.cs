using System.Collections.Generic;
using System.Linq;
using Learn.ViewComponent.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Learn.ViewComponent.Components
{
    /*
     * Компонент должен содержать суффикс ViewComponent 
     * или быть наследованым от ViewComponent.
     * Так же можно использовать атрибут [ViewComponent], 
     * в таком случае суффикс и наследование не требуется.
     */
    public class BestCarViewComponent
    {
        private List<Car> cars;

        public BestCarViewComponent()
        {
            cars = new List<Car>
            {
                new Car { Model = "Tesla Model S", Price = 100900 },
                new Car { Model = "Tesla Model X", Price = 137700 },
                new Car { Model = "Tesla Model 3", Price = 52000 }
            };
        }

        //public string Invoke()
        //{
        //    var item = cars.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
        //    return $"Самая дорогая модель: {item.Model}  Цена: {item.Price}";
        //}


        // IViewComponentResult позволяет генерировать контент для представлений.

        /*
         * ViewViewComponentResult: используется для генерации представления Razor с возможностью передачи модели. 
         *                          Для создания этого объекта может применяться метод View() класса ViewComponent
         * ContentViewComponentResult: применяется для отправки текстового контента. 
         *                          Для создания объекта используется метод Content()
         * HtmlContentViewComponentResult: представляет фрагмент кода HTML, который инкорпорируется в веб-станицу
         */
        public IViewComponentResult Invoke()
        {
            var item = cars.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
            return new HtmlContentViewComponentResult(new HtmlString($"<h3>Самая дорогая модель: {item.Model}  Цена: {item.Price}</h3>"));
        }
    }
}
