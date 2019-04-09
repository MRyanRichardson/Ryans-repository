using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsModel.Model;

namespace GuildCarsData.Repository
{
    class MockRepository : IGuildCars
    {
        private List<BodyStyles> _bodystyles;
        private List<ExteriorColors> _exteriorcolors;
        private List<Contacts> _contacts;
        private List<Makes> _makes;
        private List<Models> _models;
        private List<Sales> _purchases;
     
        private List<Specials> _specials;
      
        private List<Vehicles> _vehicles;

        private List<VehicleDisplay> _vehicleDisplay;





        public MockRepository()
        {
            _vehicleDisplay = new List<VehicleDisplay>()
            {
                new VehicleDisplay(){VehicleID=1,Year=2018,BodyStyleType="Truck",InteriorColor="Blue",CarColor="Blue",ModelType="F150",MakeType="Ford",TransmissionType="Automatic",Mileage=12345,VIN="s3rcsdfweefffsd",SalePrice=14999,MSRP=15499,Featured=false,Description="Ford F150"}
        };



            _bodystyles = new List<BodyStyles>()
            {
                new BodyStyles() { BodyStyleID = 1, BodyStyleType = "Car" },
                new BodyStyles() { BodyStyleID = 2, BodyStyleType = "Truck" },
                new BodyStyles() { BodyStyleID = 3, BodyStyleType = "SUV" },
                new BodyStyles() { BodyStyleID = 4, BodyStyleType = "Van" }
            };
            _exteriorcolors = new List<ExteriorColors>()
            {
                new ExteriorColors() { ColorID = 1 , CarColor = "White" },
                new ExteriorColors() { ColorID = 2 , CarColor = "Beige" },
                new ExteriorColors() { ColorID = 3 , CarColor = "Gold" },
                new ExteriorColors() { ColorID = 4 , CarColor = "Black" },
                new ExteriorColors() { ColorID = 5 , CarColor = "Red" },
                new ExteriorColors() { ColorID = 6 , CarColor = "Green" },
                new ExteriorColors() { ColorID = 7 , CarColor = "Silver" },
                new ExteriorColors() { ColorID = 8 , CarColor = "Yellow" },
                new ExteriorColors() { ColorID = 9 , CarColor = "Brown" },
                new ExteriorColors() { ColorID = 10, CarColor = "Burgundy" },
                new ExteriorColors() { ColorID = 11, CarColor = "Blue" },
                new ExteriorColors() { ColorID = 12, CarColor = "Navy" },
                new ExteriorColors() { ColorID = 13, CarColor = "Camoflauge" },
                new ExteriorColors() { ColorID = 14, CarColor = "Grey" }
            };
            _contacts = new List<Contacts>()
            {
                new Contacts()
                {
                    ContactId = 1, ContactName ="Glenn Quagmire" 
                },
                new Contacts()
                {
                    ContactId = 2, ContactName ="Cleveland Brown"
                },
                new Contacts()
                {
                    ContactId = 3, ContactName ="Joe Swanson"
                }
            };
            _makes = new List<Makes>()
            {
                new Makes() { MakeID = 1, MakeType = "Toyota", UserID = 1, DateAdd = DateTime.Now },
                new Makes() { MakeID = 2, MakeType = "Chevy", UserID = 1, DateAdd = DateTime.Now },
                new Makes() { MakeID = 3, MakeType = "Cadillac", UserID = 1, DateAdd = DateTime.Now },
                new Makes() { MakeID = 4, MakeType = "Honda", UserID = 1, DateAdd = DateTime.Now },
                new Makes() { MakeID = 5, MakeType = "Nissan", UserID = 1, DateAdd = DateTime.Now }
            };
            _models = new List<Models>()
            {
                new Models() { ModelID = 2 , ModelType = "Camry", MakeID = 1,  UserId = 1, DateAdded = DateTime.Now },
                new Models() { ModelID = 6 , ModelType = "S10", MakeID = 2,  UserId = 1, DateAdded = DateTime.Now },
                new Models() { ModelID = 9 , ModelType = "Escalade", MakeID = 3,  UserId = 1, DateAdded = DateTime.Now },
                new Models() { ModelID = 8 , ModelType = "Pilot", MakeID = 4,  UserId = 1, DateAdded = DateTime.Now },
                new Models() { ModelID = 18, ModelType = "Sentra", MakeID = 5,  UserId = 1, DateAdded = DateTime.Now }
            };
            _vehicles = new List<Vehicles>()
            {
                new Vehicles()
                {
                    TransmissionID = 1, BodyStyleID = 1, ColorID = 3,     Description = "A sporty car.", Featured = false, InteriorID = 2,   Mileage = 23545, ModelID = 2,  MSRP = 10000, New = false, SalePrice = 8500,  VehicleID = 1, VIN = "3XAMP73V1N1", Year = 2010
                },
                new Vehicles()
                {
                    TransmissionID = 1, BodyStyleID = 2,  ColorID = 1,  Description = "A classic truck.", Featured = false,  InteriorID = 4,  Mileage = 72888, ModelID = 6,  MSRP = 8000, New = false, SalePrice = 7000,  VehicleID = 2, VIN = "3XAMP73V1N2", Year = 2011
                },
                new Vehicles()
                {
                    TransmissionID = 0, BodyStyleID = 3,  ColorID = 4,   Description = "A classy suburban.", Featured = true,  InteriorID = 2,  Mileage = 900, ModelID = 9,  MSRP = 45000, New = true, SalePrice = 38000,  VehicleID = 3, VIN = "3XAMP73V1N3", Year = 2017
                },
                new Vehicles()
                {
                    TransmissionID = 1, BodyStyleID = 3,  ColorID = 1,  Description = "A solID crossover.", Featured = false,  InteriorID = 2,  Mileage = 520, ModelID = 8,  MSRP = 20000, New = true, SalePrice = 17500,  VehicleID = 4, VIN = "3XAMP73V1N4", Year = 2016
                }
            };


        }


        public void AddContact(Contacts contact)
        {
            contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            _contacts.Add(contact);
        }

        public void AddMake(Makes make)
        {
            make.MakeID = _makes.Max(m => m.MakeID) + 1;
            _makes.Add(make);
        }

        public void AddModel(Models model)
        {
            model.ModelID = _models.Max(m => m.ModelID) + 1;
            model.MakeID = _makes.FirstOrDefault(m => m.MakeID == model.MakeID).MakeID;
            _models.Add(model);
        }

        public void AddPurchase(Sales sale)
        {
            throw new NotImplementedException();
        }

        public void AddSpecial(Specials special)
        {
            special.SpecialID = _specials.Max(s => s.SpecialID) + 1;
            _specials.Add(special);
        }

        public int AddVehicle(Vehicles vehicle)
        {
            vehicle.VehicleID = _vehicles.Max(v => v.VehicleID) + 1;

         

            _vehicles.Add(vehicle);
            return vehicle.VehicleID;
        }

        public void DeleteSpecials(int id)
        {
            _specials.RemoveAll(s => s.SpecialID == id);
        }

        public void DeleteVehicle(int id)
        {
            _vehicles.RemoveAll(v => v.VehicleID == id);
        }

        public void EditVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleDisplay EditVehicle(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> GetAll(bool includeSold)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> GetAvailable()
        {
            throw new NotImplementedException();
        }

        public List<BodyStyles> GetBodyStyles()
        {
            throw new NotImplementedException();
        }

        public VehicleDisplay GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExteriorColors> GetColors()
        {
            throw new NotImplementedException();
        }

        public List<Contacts> GetContacts()
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> GetFeatured()
        {
            throw new NotImplementedException();
        }

        public List<Interiors> getInteriors()
        {
            throw new NotImplementedException();
        }

        public List<vehicleInventory> GetInventory(bool newUsed)
        {
            throw new NotImplementedException();
        }

        public Makes GetMakeByModelId(int ModelId)
        {
            throw new NotImplementedException();
        }

        public List<MakeModel> GetMakeModels()
        {
            throw new NotImplementedException();
        }

        public List<Makes> GetMakes()
        {
            throw new NotImplementedException();
        }

        public List<Models> GetModels()
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> GetNew()
        {
            throw new NotImplementedException();
        }

        public List<Sales> GetPurchases()
        {
            throw new NotImplementedException();
        }

        public List<SalesItems> getSalesSearch(string UserName, string from, string to)
        {
            throw new NotImplementedException();
        }

        public SpecialAndFeatured GetSpecialAndFeatured()
        {
            throw new NotImplementedException();
        }

        public List<Specials> GetSpecials()
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> GetUsed()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        //public VehicleAll getVehicleAll()
        //{
        //    throw new NotImplementedException();
        //}

        public Vehicles GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDisplay> SearchVehicles(Search sItem)
        {
            throw new NotImplementedException();
        }

        void IGuildCars.EditVehicle(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
