using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Controllers.Controllers
{
    // [NonController] - Атрибут позволяет не рассматривать класс, как контроллер.
    public class HelloController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // [NonAction] - Не рассматривает метод, как действие контроллера.
        [ActionName("Welcome")] // Атрибут позволяет для метода задать другое имя действия.
        public string Hello()
        {
            return "Hello ASP.NET";
        }
    }
}
