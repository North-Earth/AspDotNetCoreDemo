using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}