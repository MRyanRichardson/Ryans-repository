
using GuildCarsData;
using GuildCarsModel.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsTest.ADOTest
{
    [TestFixture]
    public class ADOTest
    {
        private IGuildCars _repo;
        private int vehicleId = 0;

        [SetUp]
        public void Init()
        {
            _repo = Settings.GetRepository();
        }



        [Test]
        public void CanGetAll()
        {
            List<VehicleDisplay> ve = _repo.GetAll(false);
            List<BodyStyles> bs = _repo.GetBodyStyles();
            List<ExteriorColors> ec = _repo.GetColors();
            List<Interiors> inter = _repo.getInteriors();
            List<Makes> ma = _repo.GetMakes();
            List<Models> mo = _repo.GetModels();

            Assert.Greater(ve.Count, 0);
        }

        [Test]
        public void CanGetVehicles()
        {
            List<VehicleDisplay> ve = _repo.GetAll(false);
            Assert.Greater(ve.Count, 0);
        }
        [Test]
        public void CanGetBodyStyles()
        {
            List<BodyStyles> bs = _repo.GetBodyStyles();
            Assert.Greater(bs.Count, 0);
        }
        [Test]
        public void CanGetColors()
        {
            List<ExteriorColors> ec = _repo.GetColors();
            Assert.Greater(ec.Count, 0);
        }
        [Test]
        public void CangetInterior()
        {
            List<Interiors> inter = _repo.getInteriors();
            Assert.Greater(inter.Count, 0);
        }
        [Test]
        public void CanGetMakes()
        {
            List<Makes> ma = _repo.GetMakes();
            Assert.Greater(ma.Count, 0);
        }
        [Test]
        public void CanGetModels()
        {
            List<Models> mo = _repo.GetModels();
            Assert.Greater(mo.Count, 0);
        }

    

        [Test]
        public void aaCanAddVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles()
            {
                Year = 2019,
                BodyStyleID = 1,
                ColorID = 1,
                Mileage = 65432,
                VIN = "1234567890ABCDEFG",
                ModelID = 1,
                InteriorID = 1,
                SalePrice = 50000,
                MSRP = 55000,
                UserID = 1,
                TransmissionID = 1,
                Featured = false,
                Description = "ADO Test Vehicle",
                New = false
            };

            vehicleId = _repo.AddVehicle(vehicleToAdd);


            Vehicles addedVehicle = _repo.GetVehicleById(vehicleId);

            Assert.AreEqual(vehicleToAdd.TransmissionID, addedVehicle.TransmissionID);
            Assert.AreEqual(vehicleToAdd.ModelID, addedVehicle.ModelID);
            Assert.AreEqual(vehicleToAdd.SalePrice, addedVehicle.SalePrice);
            Assert.AreEqual(vehicleToAdd.Mileage, addedVehicle.Mileage);
            Assert.AreEqual(vehicleToAdd.VIN, addedVehicle.VIN);
            Assert.AreEqual(vehicleToAdd.Year, addedVehicle.Year);
            Assert.AreEqual(vehicleToAdd.BodyStyleID, addedVehicle.BodyStyleID);
            Assert.AreEqual(vehicleToAdd.ColorID, addedVehicle.ColorID);
        }


        [Test]
        public void bbCanGetById()
        {
            Vehicles vehicle = _repo.GetVehicleById(vehicleId);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, vehicle.TransmissionID);
            Assert.AreEqual(1, vehicle.BodyStyleID);

            Assert.AreEqual(1, vehicle.ColorID);


            Assert.AreEqual(false, vehicle.Featured);
            Assert.AreEqual(1, vehicle.InteriorID);
            Assert.AreEqual(65432, vehicle.Mileage);
            Assert.AreEqual(1, vehicle.ModelID);

            Assert.AreEqual(55000.00, vehicle.MSRP);
            Assert.AreEqual(false, vehicle.New);
            Assert.AreEqual(50000.00, vehicle.SalePrice);

            Assert.AreEqual("1234567890ABCDEFG", vehicle.VIN);
            Assert.AreEqual(2019, vehicle.Year);
        }

        [Test]
        public void ccCanEditVehicle()
        {
            Vehicles vehicleToEdit = _repo.GetVehicleById(vehicleId);

            IGuildCars repo = Settings.GetRepository();


            vehicleToEdit.Year = 1999;
            vehicleToEdit.BodyStyleID = 1;
            vehicleToEdit.ColorID = 1;
            vehicleToEdit.Mileage = 1111;
            vehicleToEdit.ModelID = 1;
            vehicleToEdit.InteriorID = 1;
            vehicleToEdit.SalePrice = 2222;
            vehicleToEdit.MSRP = 3333;
            vehicleToEdit.UserID = 1;

            repo.EditVehicle(vehicleToEdit);

            Vehicles editedVehicle = _repo.GetVehicleById(vehicleId);

            Assert.AreEqual(1999, editedVehicle.Year);
            Assert.AreEqual(1111, editedVehicle.Mileage);
            Assert.AreEqual(2222.00, editedVehicle.SalePrice);
            Assert.AreEqual(3333.00, editedVehicle.MSRP);
        }

        [Test]
        public void ddCanXDeleteVehicle()
        {
            Vehicles vehicleToDelete = _repo.GetVehicleById(vehicleId);

            Assert.IsNotNull(vehicleToDelete);

            _repo.DeleteVehicle(vehicleId);

            Vehicles deletedVehicle = _repo.GetVehicleById(vehicleId);

            Assert.AreEqual(0,deletedVehicle.VehicleID);
        }

        [Test]
        public void eeCanGetNewVehicles()
        {
            List<VehicleDisplay> ve = _repo.GetNew();

            Assert.Greater(ve.Count, 0);

        }

        [Test]
        public void ffCanGetUsedVehicles()
        {
            List<VehicleDisplay> ve = _repo.GetNew();

            Assert.Greater(ve.Count, 0);
        }



      
    }
}
