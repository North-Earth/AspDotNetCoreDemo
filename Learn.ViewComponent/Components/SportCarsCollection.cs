using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learn.ViewComponent.Components
{
    public class SportCarsCollection : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private List<Car> sportCars;

        public SportCarsCollection()
        {
            sportCars = new List<Car>
            {
                new Car { Model = "Acura NSX", Price = 150000 },
                new Car { Model = "Audi R8", Price = 178000 },
                new Car { Model = "CHEVROLET CORVETTE - VI", Price = 140000 },
            };
        }

        /// <summary>
        /// Показывает все спорткары в наличии.
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            return View("MainView", sportCars);
        }

        /// <summary>
        /// Возвращает все спорткары в заданом ценовом диапазоне.
        /// </summary>
        /// <param name = "minPrice" ></ param >
        /// < param name="maxPrise"></param>
        /// <returns></returns>
        //public IViewComponentResult Invoke(int maxPrise, int minPrice = 0)
        //{
        //    var cars = sportCars.Where(sc => sc.Price >= minPrice && sc.Price <= maxPrise).ToList();
        //    return View("MainView", cars);
        //}
    }
}
