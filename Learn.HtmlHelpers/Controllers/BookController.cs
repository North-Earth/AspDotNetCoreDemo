using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.HtmlHelpers.Controllers
{
    public class BookController : Controller
    {
        public string Index(string author = "Толстой", int id = 1)
        {
            return author + "  " + id.ToString();
        }

        public string Show()
        {
            return "Test";
        }
    }
}