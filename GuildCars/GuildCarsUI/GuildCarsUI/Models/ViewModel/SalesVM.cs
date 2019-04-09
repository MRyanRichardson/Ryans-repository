using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Models.ViewModel
{
    public class SalesVM
    {
        public List<Users> lUsers { get; set; }
        public List<SalesItems> sItems { get; set; }
        public List<SelectListItem> model { get; set; }


    }
}