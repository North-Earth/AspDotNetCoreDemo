using System.Collections.Generic;

namespace Learn.ViewComponent.Models
{
    public interface IRepository
    {
        List<Car> GetCars();
    }
}
