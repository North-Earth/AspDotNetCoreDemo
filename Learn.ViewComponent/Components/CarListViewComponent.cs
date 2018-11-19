using System.Linq;
using Learn.ViewComponent.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Learn.ViewComponent.Components
{
    public class CarListViewComponent
    {
        private IRepository repository;

        public CarListViewComponent(IRepository rep)
        {
            repository = rep;
        }

        public string Invoke(int maxPrice = 999999, int minPrice = 0)
        {
            int count = repository.GetCars().Count(x => x.Price < maxPrice && x.Price > minPrice);
            return $"В диапазоне от {minPrice} до {maxPrice} найдено {count} модели(ей)";
        }
    }
}
