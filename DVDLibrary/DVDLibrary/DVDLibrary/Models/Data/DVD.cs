using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DVDLibrary.Models.Data
{
    public class DVD
    {
        public int DvdId { get; set; }
        public string title { get; set; }
        public int realeaseYear { get; set; }
        public string notes { get; set; }
    }
}