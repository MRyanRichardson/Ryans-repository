using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsModel.Model;

namespace GuildCarsData
{
    public interface IGuildCars
    {
        void AddMake(Makes make);
        void AddModel(Models model);
        void AddPurchase(Sales sale);
        void AddSpecial(Specials special);
        int AddVehicle(Vehicles vehicle);
        void DeleteSpecials(int id);
        void DeleteVehicle(int id);
        void EditVehicle(Vehicles vehicle);
        List<VehicleDisplay> GetAll(bool includeSold);
        List<BodyStyles> GetBodyStyles();
        VehicleDisplay GetById(int id);
        List<ExteriorColors> GetColors();
        List<VehicleDisplay> GetFeatured();
        SpecialAndFeatured GetSpecialAndFeatured();
        List<Makes> GetMakes();
        Makes GetMakeByModelId(int ModelId);
        List<Models> GetModels();
        List<VehicleDisplay> GetNew();
        List<Sales> GetPurchases();
        //List<PurchaseType> GetPurchaseTypes();
        List<Specials> GetSpecials();
        //List<States> GetStates();
        List<VehicleDisplay> GetUsed();
        //List<Vehicles> SearchVehicles(SearchItems search);
        List<VehicleDisplay> GetAvailable();
        List<VehicleDisplay> SearchVehicles(Search sItem);
        //VehicleAll getVehicleAll();
        List<Interiors> getInteriors();
        List<MakeModel> GetMakeModels();
        List<vehicleInventory> GetInventory(bool newUsed);
        Vehicles GetVehicleById(int id);
        List<Users> GetUsers();
        List<SalesItems> getSalesSearch(string UserName, string from, string to);

    }

}
