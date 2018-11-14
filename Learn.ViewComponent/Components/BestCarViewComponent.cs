using System.Collections.Generic;
using System.Linq;
using Learn.ViewComponent.Models;

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
                new Car {Model = "Tesla Model S", Price = 100900 },
                new Car {Model = "Tesla Model X", Price = 137700 },
            };
        }

        public string Invoke()
        {
            var item = cars.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
            return $"Самая дорогая модель: {item.Model}  Цена: {item.Price}";
        }
    }
}
