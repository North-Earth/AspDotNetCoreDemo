using System.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Controllers.Controllers
{
    // [NonController] - Атрибут позволяет не рассматривать класс, как контроллер.
    public class HelloController : Controller
    {
        // [NonAction] - Не рассматривает метод, как действие контроллера.
        [ActionName("Welcome")] // Атрибут позволяет для метода задать другое имя действия.
        public string Hello(string name)
        {
            return name != null ? $"Hello, {name}!" : "Hello!";
        }

        public string Square(int a = 3, int h = 10) //Разрешено использование параметров по умолчанию.
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }

        public string Square(Geometry geometry)
        {
            return $"Площадь треугольника с основанием {geometry.Altitude} " +
                $"и высотой {geometry.Height} равна {geometry.GetSquare()}";
        }

        // [Controller]/Sum?nums=1&nums=2&nums=3
        public string Sum(int[] nums)
        {
            return $"Сумма числел равна {nums.Sum()}";
        }

        // [Controller]/Sum?geoms[0].altitude=10&geoms[0].height=3&geoms[1].altitude=16&geoms[1].height=2
        public string Sum(Geometry[] geoms)
        {
            return $"Сумма площадей равна {geoms.Sum(g => g.GetSquare())}";
        }
    }

    public class Geometry
    {
        // Основание.
        public int Altitude { get; set; }

        // Высота.
        public int Height { get; set; }

        // Вычисление площади треугольника.
        public double GetSquare()
        {
            return Altitude * Height / 2;
        }
    }
}
