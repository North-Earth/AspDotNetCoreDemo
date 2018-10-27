using System;

namespace Learn.Controllers.Models
{
    public class SimpleTimeService : ITimeService
    {
        public SimpleTimeService()
        {
            Time = DateTime.Now.ToString("hh:mm:ss");
        }

        public string Time { get; }
    }
}
