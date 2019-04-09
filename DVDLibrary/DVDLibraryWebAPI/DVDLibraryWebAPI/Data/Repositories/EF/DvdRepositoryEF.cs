using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DVDLibraryWebAPI.Models.Interfaces;
using DVDLibraryWebAPI.Models.Data;
namespace DvdLibraryWebApi.Data.Repositories.EF
{
    public class DvdRepositoryEF : DbContext, IDvdRepository
    {   //constructor setting base to our SQL database
        public DvdRepositoryEF() : base("DvdDatabaseEF")
        {
        }
        //db to call rating director and dvds from SQL database dvdlibrary3
        public DbSet<DVD> DVDs { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Director> Director { get; set; }
        public DVD Add(DVD dvd)
        //interface
        {
            DVDs.Add(dvd);
            //Update Directors object with the new director name entered on the screen.
            //If the director does not exist in the table, it will be inserted and the new Director id will be assigned to the DVDs table automatically
            dvd.Directors = new Director();
            dvd.Directors.DirectorName = dvd.director;
            //Update Ratings object with the new Rating name entered on the screen.
            //If the Rating does not exist in the table, it will be inserted and the new Rating id will be assigned to the DVDs table automatically
            dvd.Ratings = new Rating();
            dvd.Ratings.RatingName = dvd.rating;
            SaveChanges();
            return dvd;
        }
        public void Delete(int id)
        {
            //Select the DVD to be delete.
            DVD d = DVDs.FirstOrDefault(c => c.dvdId == id);
            if (d == null)
            {
                return;
            }
            else
            {
                //Delete dvd from table
                DVDs.Remove(d);
                SaveChanges();
            }
        }
        public List<DVD> GetAll()
        {
            return DVDs.ToList();
        }
        public DVD GetById(int id)
        {
            return DVDs.FirstOrDefault(d => d.dvdId == id);
        }
        public List<DVD> SearchByDirector(string directorName)
        {
            IEnumerable<DVD> result = from d in DVDs
                                      where d.Directors.DirectorName.Contains(directorName)
                                      select d;
            return result.ToList();
        }
        public List<DVD> SearchByRating(string rating)
        {
            IEnumerable<DVD> result = from d in DVDs
                                      where d.Ratings.RatingName.Contains(rating)
                                      select d;
            return result.ToList();
        }
        public List<DVD> SearchByReleaseYear(int year)
        {
            IEnumerable<DVD> result = from d in DVDs
                                      where d.realeaseYear == year
                                      select d;
            return result.ToList();
        }
        public List<DVD> SearchByTitle(string title)
        {
            IEnumerable<DVD> result = from d in DVDs
                                      where d.title.Contains(title)
                                      select d;
            return result.ToList();
        }
        public void Update(DVD dvd)
        {
            //Grab existing record using the dvdId
            DVD d = DVDs.FirstOrDefault(c => c.dvdId == dvd.dvdId);
            //update existing record with new data entered on DVD Edit screen
            d.Directors.DirectorName = dvd.director;
            d.Ratings.RatingName = dvd.rating;
            d.title = dvd.title;
            d.director = d.Directors.DirectorName;
            d.realeaseYear = dvd.realeaseYear;
            d.rating = d.Ratings.RatingName;
            d.notes = dvd.notes;
            SaveChanges();
        }
    }
}