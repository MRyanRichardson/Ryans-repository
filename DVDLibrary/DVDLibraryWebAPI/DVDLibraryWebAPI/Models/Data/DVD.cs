using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DVDLibraryWebAPI.Models.Data
{    //Class for DVD Data 
    public class DVD
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public int realeaseYear { get; set; }
        public string notes { get; set; }
        public int RatingId { get; set; }
        public int DirectorId { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public virtual Rating Ratings { get; set; }
        public virtual Director Directors { get; set; }
    }
}