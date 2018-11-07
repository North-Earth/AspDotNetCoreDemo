using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Views.Controllers
{
    public class ViewEngineController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About()
        {
            return View("About");
        }
        public ViewResult Contact()
        {
            return View();
        }
    }
}