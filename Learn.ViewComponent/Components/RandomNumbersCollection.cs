using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn.ViewComponent.Components
{
    public class RandomNumbersCollection : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collection = new List<int>();
            var random = new Random();

            for (int i = 0; i < 200; i++)
            {
                collection.Add(random.Next(int.MaxValue));
                await Task.Delay(100);
            }

            return View("", collection);
        }
    }
}
