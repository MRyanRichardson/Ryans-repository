using DvdLibraryWebApi.Data.Repositories.EF;
using DvdLibraryWebApi.Data.Repositories.SampleData;
using DVDLibraryWebAPI.Data;
using DVDLibraryWebAPI.Models.Data.ADO;
using DVDLibraryWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace DVDLibraryWebAPI.Controllers
{   //decides which repository to use, set in our web config file
    public static class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            var setting = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (setting)
            {
                case "DvdRepositoryMock":
                    return new DvdRepositoryMock();
                case "DvdRepositoryADO":
                    return new DvdRepositoryADO();
                case "DvdRepositoryEF":
                    return new DvdRepositoryEF();
                default:
                    return null;
            }
        }
    }
}