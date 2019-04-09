using DVDLibraryWebAPI.Data;
using DVDLibraryWebAPI.Models.Data;
using DVDLibraryWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace DVDLibraryWebAPI.Controllers
{
    //Home controller which handles all data request
    public class HomeController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            IDvdRepository repo = Settings.GetRepository();
            List<DVD> result = updateItems(repo.GetAll());
            return Ok(result);
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            IDvdRepository repo = Settings.GetRepository();
            DVD result = repo.GetById(id);
            result.director = result.director == null ? result.Directors.DirectorName : result.director;
            result.rating = result.rating == null ? result.Ratings.RatingName : result.rating;
            return Ok(result);
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DVDDelete(int id)
        {
            IDvdRepository repo = Settings.GetRepository();
            repo.Delete(id);
            return Ok();
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult DVDUpdate(DVD dvd)
        {
            IDvdRepository repo = Settings.GetRepository();
            repo.Update(dvd);
            return Ok(dvd);
        }
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult DVDInsert(DVD dvd)
        {
            IDvdRepository repo = Settings.GetRepository();
            return Ok(repo.Add(dvd));
        }
        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByDirector(string directorName)
        {
            IDvdRepository repo = Settings.GetRepository();
            List<DVD> result = updateItems(repo.SearchByDirector(directorName));
            return Ok(result);
        }
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByRating(string rating)
        {
            IDvdRepository repo = Settings.GetRepository();
            List<DVD> result = updateItems(repo.SearchByRating(rating));
            return Ok(result);
        }
        [Route("dvds/releasedate/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByReleaseYear(int releaseYear)
        {
            IDvdRepository repo = Settings.GetRepository();
            List<DVD> result = updateItems(repo.SearchByReleaseYear(releaseYear));
            return Ok(result);
        }
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByReleaseTitle(string title)
        {
            IDvdRepository repo = Settings.GetRepository();
            List<DVD> result = updateItems(repo.SearchByTitle(title));
            return Ok(result);
        }
        private List<DVD> updateItems(List<DVD> list)
        {
            foreach (DVD d in list)
            {
                d.director = d.director == null ? d.Directors.DirectorName : d.director;
                d.rating = d.rating == null ? d.Ratings.RatingName : d.rating;
            }
            return list;
        }
    }
}