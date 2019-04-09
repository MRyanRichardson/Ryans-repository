using GuildCarsData.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuildCarsData.Factory
{
    class GuildCarsRepositoryFactory
    {
        public static IGuildCars Create()
        {
            var setting = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (setting)
            {
                case "GuildCarsRepositoryADO":
                    return new GuildCarsRepositoryADO();
                case "TestData":
                    return null;
                default:
                    return null;
            }
        }
    }
}
