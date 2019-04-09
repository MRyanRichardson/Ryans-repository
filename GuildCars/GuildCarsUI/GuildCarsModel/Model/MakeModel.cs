using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsModel.Model
{
    //makemodel (Viewmodel) for our Admin Models view
  public  class MakeModel
    {
        public string Make { get; set; }
        public string Model  { get; set; }
        public DateTime DateAdd { get; set; }
        public string UserEmail { get; set; }
    }
}
