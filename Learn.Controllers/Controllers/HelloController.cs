﻿using System;
using System.Linq;
using Learn.Controllers.Util;
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

        [HttpPost]
        public IActionResult Square(int altitude, int height) // Разрешено использование параметров по умолчанию.
        {
            double square = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}");
        }

        public string Square(Geometry geometry)
        {
            return $"Площадь треугольника с основанием {geometry.Altitude} " +
                $"и высотой {geometry.Height} равна {geometry.GetSquare()}";
        }

        public string SquareQuery() // Получение данных из строки запроса внутри метода.
        {
            string altitudeString = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }

        [HttpPost]
        public string SquareQueryForm() // Получение данных из  отправленной формы запроса внутри метода.
        {
            string altitudeString = Request.Form.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Form.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
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

        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
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