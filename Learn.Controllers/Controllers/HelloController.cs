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

        public string Square(Geometry geometry) //Разрешено использование параметров по умолчанию.
        {
            return $"Площадь треугольника с основанием {geometry.Altitude} " +
                $"и высотой {geometry.Height} равна {geometry.GetSquare()}";
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
