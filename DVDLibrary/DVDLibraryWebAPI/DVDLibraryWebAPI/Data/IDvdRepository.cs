using DVDLibraryWebAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVDLibraryWebAPI.Models.Interfaces
{
    //Interface to populate all Repositories
    public interface IDvdRepository
    {
        List<DVD> GetAll();
        DVD GetById(int id);
        List<DVD> SearchByTitle(string title);
        List<DVD> SearchByReleaseYear(int year);
        List<DVD> SearchByDirector(string directorName);
        List<DVD> SearchByRating(string rating);
        DVD Add(DVD dvd);
        void Update(DVD dvd);
        void Delete(int id);
    }
}
