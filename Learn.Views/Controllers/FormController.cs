using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Views.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password, int age, string comment, bool isMarried, string color, string car, string[] cars)
        {
            string content = $"Login: {login}  " +
                $" Password: {password}  " +
                $" Age: {age}  " +
                $"Comment: {comment} " +
                $"isMarried: {isMarried} " +
                $"color: {color} " +
                $"car: {car} ";

            foreach (string c in cars)
            {
                content += c;
                content += "; ";
            }
            return Content(content);
        }
    }
}