using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Learn.Models.Models;
using Learn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Models.Controllers
{
    public class HomeController : Controller
    {
        private List<Company> companies;
        private List<Car> cars;
        static List<Event> events;

        public HomeController()
        {
            companies = new List<Company>
            {
                new Company { Id = 1, Name = "Mazda", Country = "Япония" },
                new Company { Id = 2, Name = "Toyota", Country = "Япония" },
                new Company { Id = 3, Name = "Ford", Country = "США" }
            };

            cars = new List<Car>
            {
                new Car { Id = 1, Manufacturer = companies[0], Model = "3", Price = 950000 },
                new Car { Id = 2, Manufacturer = companies[1], Model = "CX-5", Price = 1500000 },
                new Car { Id = 3, Manufacturer = companies[2], Model = "Focus", Price = 600000 },
            };

            if (events == null)
                events = new List<Event>();
        }

        public IActionResult Event()
        {

            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            ev.Id = Guid.NewGuid().ToString();
            events.Add(ev);
            return RedirectToAction("Index");
        }

        public IActionResult AddSecondUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSecondUser([FromQuery] SecondUser user)
        {
            string userInfo = $"Name: {user.Name}  Age: {user.Age}";
            return Content(userInfo);
        }

        //Home/AddUser?Name=name&Age=20&HasRight=true
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
                return Content(userInfo);
            }
            return Content($"Количество ошибок: {ModelState.ErrorCount}");
        }

        //Атрибут Bind позволяет установить выборочную привязку отдельных значений.
        public IActionResult AddUserBind([Bind("Name", "Age")] User user)
        {
            string userInfo = $"Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
            return Content(userInfo);
        }

        /*
         * [FromHeader]: данные берутся из заголовоков запроса.
         * [FromQuery]:  данные берутся из строки запроса.
         * [FromRoute]:  данные берутся из значений маршрута.
         * [FromForm]:   данные берутся из полученных форм.
         * [FromBody]:   данные берутся из тела запроса. Этот атриут может применяться, 
         *               когда в качестве источника данных выступает не форма и не строка запроса, 
         *               а, скажем, данные отправляются через код javascript.
         * Атрибут FromBody может применяться, если метод имеет только один параметр, иначе будет сгенерировано исключение.
         */
        public IActionResult GetUserAgent([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Content(userAgent);
        }

        public IActionResult Index(int? companyId)
        {    
            // Формируем список компаний для передачи в представление.
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel { Id = c.Id, Name = c.Name })
                .ToList();

            // Добавляем на первое место.
            compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });

            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Cars = cars };

            // если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                ivm.Cars = cars.Where(p => p.Manufacturer.Id == companyId);

            return View(ivm);
        }

        public IActionResult GetData()
        {
            return View();
        }

        public IActionResult GetCar(Car car)
        {
            return Content($" Марка: {car.Manufacturer} Модель: {car.Model} Цена: {car.Price}");
        }

        public IActionResult GetDataArray(string[] items)
        {
            string result = "";
            foreach (var item in items)
                result += item + "; ";
            return Content(result);
        }

        public IActionResult GetDataDictionary(Dictionary<string, string> items)
        {
            string result = "";
            foreach (var item in items)
                result += item.Key + "= " + item.Value + "; ";
            return Content(result);
        }

        public IActionResult About(string name)
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
