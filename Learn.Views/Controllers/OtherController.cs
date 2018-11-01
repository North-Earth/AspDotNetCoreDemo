using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Views.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public IActionResult Index()
        {
            return View();
        }
    }
}