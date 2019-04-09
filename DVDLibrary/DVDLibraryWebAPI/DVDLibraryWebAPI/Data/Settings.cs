using DVDLibraryWebAPI.Controllers;
using DVDLibraryWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace DVDLibraryWebAPI.Data
{
    //gets connection string from our web config file
    // gets the repository that we are calling from web config file
    public class Settings
    {
        private static IDvdRepository _repo;
        private static string _connectionString;
        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["DvdDatabase"].ConnectionString;
            return _connectionString;
        }
        public static IDvdRepository GetRepository()
        {
            if (_repo == null)
                _repo = DvdRepositoryFactory.Create();
            return _repo;
        }
    }
}