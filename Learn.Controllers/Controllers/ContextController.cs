using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers.Controllers
{
    public class ContextController : Controller
    {
        // Responce - управление ответом на запрос.
        public void Index()
        {
            Response.StatusCode = 404;
            Response.ContentType = "application/json";
            Response.WriteAsync("Resource not found");
        }

        // Получаем данные о запросе.
        public void GetRequest()
        {
            string table = "";
            foreach (var header in Request.Headers)
            {
                table += $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>";
            }
            Response.WriteAsync(String.Format("<table>{0}</table>", table));

            // Получение информации из определённых заголовков.
            //string userAgent = Request.Headers["User-Agent"].ToString();
            //string referer = Request.Headers["Referer"].ToString();
        }
    }
}