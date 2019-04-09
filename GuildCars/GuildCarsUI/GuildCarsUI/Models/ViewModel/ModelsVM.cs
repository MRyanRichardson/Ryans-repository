using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCarsUI.Models.ViewModel
{
    public class ModelsVM
    {
        public List<MakeModel> MakeModels { get; set; }
        public List <Makes> Makes { get; set; }
        public GuildCarsModel.Model.Models modelToAdd { get; set; }

    }
}


