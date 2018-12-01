using System;

namespace Learn.Models.Models
{
    public class Event
    {
        public string Id { get; set; }

        public string Name { get; set; }            // Название события.

        public DateTime EventDate { get; set; }     // Дата и время события.
    }
}
