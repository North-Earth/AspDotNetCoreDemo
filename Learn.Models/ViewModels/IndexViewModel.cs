using System.Collections.Generic;
using Learn.Models.Models;

namespace Learn.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
