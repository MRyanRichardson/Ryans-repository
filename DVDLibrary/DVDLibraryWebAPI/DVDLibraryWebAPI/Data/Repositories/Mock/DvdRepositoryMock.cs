using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryWebAPI.Models.Data;
using DVDLibraryWebAPI.Models.Interfaces;
namespace DvdLibraryWebApi.Data.Repositories.SampleData
{
    //mock / test repository
    public class DvdRepositoryMock : IDvdRepository
    {
        //private list because this list is not used outside of this class
        private List<DVD> _dvds;
        public DvdRepositoryMock()
        {//populate static data
            _dvds = new List<DVD>()
            {
                new DVD { dvdId = 1, title = "Holy Grail", realeaseYear = 1975, director = "Terry Gilliam", rating = "PG", notes = "Ni!" },
                new DVD { dvdId = 2, title = "Naked Gun", realeaseYear = 1988, director = "David Zucker", rating = "PG-13", notes = "Don't call me Shirley" },
                new DVD { dvdId = 3, title = "Blazing Saddles", realeaseYear = 1974, director = "Mel brooks", rating = "R", notes = "Best Ever" },
                new DVD { dvdId = 4, title = "Star Wars", realeaseYear = 1977, director = "George Lucas", rating = "PG", notes = "A New Hope" }
            };
        }
        //Methods from interface
        public DVD Add(DVD dvd)
        {
            dvd.dvdId = _dvds.Max(d => d.dvdId) + 1;
            _dvds.Add(dvd);
            return dvd;
        }
        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.dvdId == id);
        }
        public List<DVD> GetAll()
        {
            return _dvds.ToList();
        }
        public DVD GetById(int id)
        {
            return _dvds.FirstOrDefault(d => d.dvdId == id);
        }
        public List<DVD> SearchByDirector(string directorName)
        {
            List<DVD> dvds = new List<DVD>();
            foreach (DVD dvd in _dvds)
            {
                if (dvd.director.ToLower().Contains(directorName.ToLower()))
                {
                    dvds.Add(dvd);
                }
            }
            return dvds.ToList();
        }
        public List<DVD> SearchByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();
            foreach (DVD dvd in _dvds)
            {
                if (dvd.rating.ToUpper() == rating.ToUpper())
                {
                    dvds.Add(dvd);
                }
            }
            return dvds;
        }
        public List<DVD> SearchByReleaseYear(int year)
        {
            List<DVD> dvds = new List<DVD>();
            foreach (DVD dvd in _dvds)
            {
                if (dvd.realeaseYear == year)
                {
                    dvds.Add(dvd);
                }
            }
            return dvds;
        }
        public List<DVD> SearchByTitle(string title)
        {
            List<DVD> dvds = new List<DVD>();
            foreach (DVD dvd in _dvds)
            {
                if (dvd.title.ToLower().Contains(title.ToLower()))
                {
                    dvds.Add(dvd);
                }
            }
            return dvds;
        }
        public void Update(DVD dvd)
        {
            var dVD = _dvds.FirstOrDefault(d => d.dvdId == dvd.dvdId);
            if (dVD != null)
            {
                dVD.title = dvd.title;
                dVD.realeaseYear = dvd.realeaseYear;
                dVD.director = dvd.director;
                dVD.rating = dvd.rating;
                dVD.notes = dvd.notes;
            }
        }
    }
}
