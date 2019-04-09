using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsUI.Models.ViewModel
{
    public class InventoryVM
    {
        public List<vehicleInventory> InventoryNew { get; set; }
        public List<vehicleInventory> InventoryUsed { get; set; }
    }
}