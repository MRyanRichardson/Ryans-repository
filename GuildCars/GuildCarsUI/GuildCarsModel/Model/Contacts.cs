using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuildCarsModel.Model
{
    //contacts only used to validate since we never had to get contact information
    public class Contacts
    {
        public int ContactId { get; set; }
        [Required]
        public string ContactName { get; set; }
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
    }
}
