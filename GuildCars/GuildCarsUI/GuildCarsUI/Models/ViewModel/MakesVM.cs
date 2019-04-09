using GuildCarsModel.Model;
using GuildCarsUI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace GuildCarsUI.Models.ViewModel
{
    public class MakesVM
    {
        public List<Makes> Makes { get; set; }
        [Required(ErrorMessage = "Please enter a name for this make")]
        [MaxLength(50, ErrorMessage = "A make name cannot be longer than 50 characters")]
        public string MakeName { get; set; }
        

    }
}