using System.Collections.Generic;
using System.Linq;
using Learn.TagHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Learn.TagHelpers.Controllers
{
    public class LearnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Create(int id, int age, string name)
        {
            return $"id:{id} age:{age} name:{name}";
        }

        private IEnumerable<Company> companies = new List<Company>
        {
            new Company { Id = 1, Name = "Apple" },
            new Company { Id = 2, Name = "Samsung" },
            new Company { Id=3, Name="Microsoft" }
        };

        public IActionResult CreatePhone()
        {
            ViewBag.Companies = new SelectList(companies, "Id", "Name");
            return View();
        }

        [HttpPost]
        public string CreatePhone(Phone phone)
        {
            Company company = companies.FirstOrDefault(c => c.Id == phone.CompanyId);
            return $"Добавлен новый элемент: {phone.Name} ({company?.Name})";
        }
    }
}