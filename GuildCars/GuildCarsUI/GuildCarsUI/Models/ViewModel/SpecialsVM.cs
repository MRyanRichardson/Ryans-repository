using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GuildCarsUI.Models.ViewModel
{
    public class SpecialsVM
    {
        public List<Specials> special { get; set; }
        public string SpecialType { get; set; }
        public string specialDescription { get; set; }
        public int UserID { get; set; }
        public Specials SpecialToAdd { get; set; }
    }
}