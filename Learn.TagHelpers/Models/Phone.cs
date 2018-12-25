using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.TagHelpers.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
