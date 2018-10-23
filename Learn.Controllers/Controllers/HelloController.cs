using System;
using System.Linq;
using Learn.Controllers.Models;
using Learn.Controllers.Util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Controllers.Controllers
{
    // [NonController] - Атрибут позволяет не рассматривать класс, как контроллер.
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            // Временная переадресация, знак "~" означает текущий каталог приложения.
            // При временной переадресации будет возвращаться статусный код 302.
            // return Redirect("~/Home/About");

            // Также можно использовать адрес внешних источников.
            //return Redirect("http://microsoft.com");

            // При постоянной переадресации будет возвращаться статусный код 301.
            //return RedirectPermanent("~/Home/About");

            // Переадресация на определенный метод контроллера.
            // return RedirectToAction("Square", "Hello", new { altitude = 10, height = 3 });

            // Переадресация по заданному маршруту из Startup
            return RedirectToRoute("default", new { controller = "Home", action = "About" 
                /*Передача входных параметров, например height = 2, altitude = 20*/ });
        }

        public IActionResult GetStatusCode()
        {
            //Ответ статус кодом.
            return StatusCode(401);
        }

        public IActionResult GetNotFoundResource()
        {
            //Отправляет статус 404.

            //return NotFound(); //Отображение статуса 404.
            return NotFound("Ресурс не найден :("); //Отображение возвращаемого объекта.
        }

        // [Controller]/UnauthorizedResult?age=18
        public IActionResult GetUnauthorizedResult(int age)
        {
            //Проверка авторизации и отправка кода 401(ограничение доступа).
            if (age < 18)
                return Unauthorized();
            return Content("Проверка пройдена");
        }

        // [Controller]/GetBadRequest?s=abc
        public ActionResult<string> GetBadRequest(string s)
        {
            // Возвращает статус 400 - нельзя обработать запрос, если не передаём значений.
            if (String.IsNullOrEmpty(s))
                return BadRequest("Не указаны параметры запроса");
            return $"s: {s}";
        }

        public IActionResult GetOkResult()
        {
            // Возвращает статус 200 об усешном выполнении запроса.

            //return Ok; //Может быть пустым или принимать параметр.
            return Ok("Запрос успешно выполнен");
        }

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

        // Возвращает HTML ответ.
        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
        }

        // Возвращает ответ в формате JSON.
        public JsonResult GetUserJson()
        {
            User user = new User { Name = "Alex", Age = 20 };
            return Json(user);
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
