using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "Please enter a State Abbreviation")]
        [MaxLength(2)]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "Please enter a State Abbreviation")]
        public string StateName { get; set; }
    }
}