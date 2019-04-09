using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsModel.Model
{
    public class Search
    {
        public string searchItem { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
        public string searchType { get; set; }
    }
}
