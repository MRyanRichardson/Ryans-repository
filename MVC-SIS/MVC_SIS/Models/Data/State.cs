using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "Please enter a state abbreviation")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        public string StateName { get; set; }
    }
}