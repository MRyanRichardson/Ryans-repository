using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMasteryData;
using System.Configuration;
namespace FlooringMastery.BLL
{   //uses dependency injection to set our repository based on appconfig
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestRepository());
                case "Production":
                    return new OrderManager(new ProductionRepository());
                default:
                    throw new NotImplementedException("Mode value in app config is not valid");
            }
        }
    }
}
