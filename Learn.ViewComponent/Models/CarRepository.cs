using System.Collections.Generic;

namespace Learn.ViewComponent.Models
{
    public class CarRepository : IRepository
    {
        public List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { Model = "Tesla Model S", Price = 100900 },
                new Car { Model = "Tesla Model X", Price = 137700 },
                new Car { Model = "Tesla Model 3", Price = 52000 }
            };
        }
    }
}
