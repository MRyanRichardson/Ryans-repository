using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsModel.Model
{
   public class Makes
    {
        public int MakeID { get; set; }
        public string MakeType { get; set; }
        public DateTime DateAdd { get; set; }
        public int UserID { get; set; }
        public string UserEmail { get; set; }
    }
}
