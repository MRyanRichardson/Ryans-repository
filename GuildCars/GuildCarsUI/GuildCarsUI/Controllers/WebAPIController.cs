using GuildCarsData;
using GuildCarsModel.Model;
using GuildCarsUI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCarsUI.Controllers
{
    public class WebAPIController : ApiController
    {
        //returns the view of our home page
        [Route("api/search/{searchTerm}/minPrice={minPrice}/maxPrice={maxPrice}/minYear={minYear}/maxYear={maxYear}/searchType={searchType}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult search(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear, string searchType)
        {
            IGuildCars repo = Settings.GetRepository();
            List<VehicleDisplay> vehicles = new List<VehicleDisplay>();

            Search sItem = new Search()
            {
                searchItem = searchTerm == "nosearchterm" ? null : searchTerm,
                minPrice = minPrice,
                maxPrice = maxPrice,
                minYear = minYear,
                maxYear = maxYear,
                searchType = searchType

            };

            return Ok(repo.SearchVehicles(sItem));
        }



        [Route("api/sales/user={userId}/from={from}/to={to}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult sales(string userId, string from, string to)
        {
            DateTime fromDate;
            DateTime toDate;

            if (long.TryParse(from, out long fromMils))
            {
                fromDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(fromMils);
            }
            else
            {
                return BadRequest("\"From Date\" was not correctly formatted. Please try again.");
            }

            if (long.TryParse(to, out long toMils))
            {
                toDate = new DateTime(2050, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(toMils);
            }
            else
            {
                return BadRequest("\"To Date\" was not correctly formatted. Please try again.");
            }

            if (userId == "0")
            {
                userId = "";
            }

            IGuildCars repo = Settings.GetRepository();
            List<SalesItems> sItems = new List<SalesItems>();
            sItems = repo.getSalesSearch(userId, fromDate.ToShortDateString(), toDate.ToShortDateString());



            return Ok(sItems);
        }
    }

}