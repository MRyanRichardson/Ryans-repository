using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Models.ViewModel
{
    public class PurchaseVM
    {
        public VehicleDisplay Vehicle { get; set; }
        public CustomerVM  Customer { get; set; }
        public SelectList FinanceTypes { get; set; }
        public SelectList States { get; set; }
    }
}

