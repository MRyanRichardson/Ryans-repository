using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsModel.Model
{
    public class Models
    {
        public int ModelID { get; set; }
        public string ModelType { get; set; }
        public int MakeID { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
    }
}
