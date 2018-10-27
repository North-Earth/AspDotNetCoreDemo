using Learn.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Learn.Controllers.Controllers
{
    public class ExampleController : Controller
    {
        private readonly ITimeService _timeService;

        public ExampleController(ITimeService timeServ)
        {
            _timeService = timeServ;
        }

        public string Index()
        {
            return _timeService.Time;
        }

        // Если нужно использовать только метод необязательно передавать всю зависимость в контроллер.
        public string GetMethod([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }

        // HttpContext.RequestServices позволяет получить доступ к всем зарегистрированным в приложении сервисам.
        public string GetService()
        {
            ITimeService timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time;
        }
    }
}