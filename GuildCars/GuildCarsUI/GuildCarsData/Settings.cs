using GuildCarsData.Factory;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsData
{
    public static class Settings
    {
        private static IGuildCars _repo;
        private static string _connectionString;
        public static IGuildCars GetRepository()
        {
            if (_repo == null)
                _repo = GuildCarsRepositoryFactory.Create();
            return _repo;
        }

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

            return _connectionString;
        }

    }
}
