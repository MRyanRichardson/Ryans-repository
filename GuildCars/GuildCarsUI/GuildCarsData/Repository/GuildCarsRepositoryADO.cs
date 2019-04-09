using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsData.Repository
{
    class GuildCarsRepositoryADO : IGuildCars
    {
        public void AddContact(Contacts contact)
        {
            throw new NotImplementedException();
        }
        //Add a new make with stored proc MakesInsert
        public void AddMake(Makes make)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakesInsert"
                };

                cmd.Parameters.AddWithValue("@MakeType", make.MakeType);
                cmd.Parameters.AddWithValue("@DateAdded", make.DateAdd);
                cmd.Parameters.AddWithValue("@UserId", make.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Add a new Model with stored proc ModelsInsert
        public void AddModel(Models model)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ModelsInsert"
                };
                cmd.Parameters.AddWithValue("@ModelType", model.ModelType);
                cmd.Parameters.AddWithValue("@MakeId", model.MakeID);
                cmd.Parameters.AddWithValue("@DateAdded", model.DateAdded);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddPurchase(Sales sale)
        {


            string query = "SalesInsert";

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = sale.VehicleID;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = sale.UserID;
                    cmd.Parameters.Add("@DateSold", SqlDbType.DateTime).Value = sale.PurchaseDate;
                    cmd.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = sale.PurchaseDate;
                    cmd.Parameters.Add("@SalePrice", SqlDbType.VarChar).Value = sale.PurchasePrice;
                    cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = sale.CustomerName;
                    cmd.Parameters.Add("@CustomerAddress1", SqlDbType.VarChar).Value = sale.CustomerAddress1;
                    cmd.Parameters.Add("@CustomerAddress2", SqlDbType.VarChar).Value = sale.CustomerAddress2;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = sale.Email;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = sale.StateAbbreviation;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = sale.City;
                    cmd.Parameters.Add("@PurchaseType", SqlDbType.VarChar).Value = sale.PurchaseTypeName;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = sale.Phone;
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void AddSpecial(Specials special)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SpecialsInsert"
                };
                cmd.Parameters.AddWithValue("@SpecialType", special.SpecialType);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);
                cmd.Parameters.AddWithValue("@UserID", special.UserID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Admin add a new vehicle
        public int AddVehicle(Vehicles vehicle)
        {

            int returnId;
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesInsert"
                };
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.ColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@SalesID", vehicle.SaleID);
                cmd.Parameters.AddWithValue("@UserID", 1);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@New", vehicle.New);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                conn.Open();
                 returnId = (int)(decimal)cmd.ExecuteScalar();
            }

            return returnId;
        }
        //Give admin choice to delete specials
        public void DeleteSpecials(int id)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()

                {

                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SpecialsDelete"
                };

                cmd.Parameters.AddWithValue("@SpecialID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //give admin choice to delete vehicle
        public void DeleteVehicle(int id)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesDelete"
                };
                cmd.Parameters.AddWithValue("@VehicleId", id);
                conn.Open();
                cmd.ExecuteNonQuery();


            }
        }
        public void EditVehicle(Vehicles vehicle)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesUpdate"
                };
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.ColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@SalesID", vehicle.SaleID);
                cmd.Parameters.AddWithValue("@UserID", 1);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@New", vehicle.New);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                conn.Open();
                cmd.ExecuteScalar();
                
            }
        }
        //public VehicleAll getVehicleAll()
        //{
        //    VehicleAll vAll = new VehicleAll(0);
        //    vAll.bodyStyles = GetBodyStyles();
        //    vAll.colors = GetColors();
        //    vAll.interiors = getInteriors();
        //    vAll.makes = GetMakes();
        //    return vAll;
        //}
        //Get all vehicles 
        public List<VehicleDisplay> GetAll(bool includeSold)
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetAll"
                };
                cmd.Parameters.AddWithValue("@IncludeSold", includeSold);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg"
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }

        public List<Users> GetUsers()
        {
            List<Users> listUsers = new List<Users>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UsersSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Users currentRow = new Users()
                        {
                            UserID = (int)dr["UserID"],
                            UserName = dr["UserName"].ToString(),
                            UserEmail = dr["Email"].ToString()
                        };

                        listUsers.Add(currentRow);
                    }
                }
            }
            return listUsers;


        }


        //get all available vehicles
        public List<VehicleDisplay> GetAvailable()
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetAvailable"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg",
                            Description = dr["Description"].ToString()
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }
        //get all bodystyles
        public List<BodyStyles> GetBodyStyles()
        {
            List<BodyStyles> listBodyStyles = new List<BodyStyles>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "BodyStylesSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyles currentRow = new BodyStyles()
                        {
                            BodyStyleID = (int)dr["BodyStyleID"],
                            BodyStyleType = dr["BodyStyleType"].ToString()
                        };
                        listBodyStyles.Add(currentRow);
                    }
                }
                return listBodyStyles;
            }
        }
        //get specific vehicle by id to return to display etc
        public VehicleDisplay GetById(int id)
        {
            VehicleDisplay vehicle = new VehicleDisplay();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehicleGetByID"
                };
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg",
                            Description = dr["Description"].ToString()
                        };
                        vehicle = currentRow;
                    }
                }
            }
            return vehicle;
        }
        //get all vehicle colors
        public List<ExteriorColors> GetColors()
        {
            List<ExteriorColors> listExteriorColors = new List<ExteriorColors>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ExteriorColorsSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColors currentRow = new ExteriorColors()
                        {
                            ColorID = (int)dr["ColorID"],
                            CarColor = dr["CarColor"].ToString()
                        };
                        listExteriorColors.Add(currentRow);
                    }
                }
                return listExteriorColors;
            }
        }
        //get all featured vehicles
        public List<VehicleDisplay> GetFeatured()
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetFeatured"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg"
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }
        //get all interior types
        public List<Interiors> getInteriors()
        {
            List<Interiors> listInteriors = new List<Interiors>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InteriorsSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interiors currentRow = new Interiors()
                        {
                            InteriorID = (int)dr["InteriorID"],
                            InteriorColor = dr["InteriorColor"].ToString()
                        };
                        listInteriors.Add(currentRow);
                    }
                }
                return listInteriors;
            }
        }
        //get all makes from stored proc makes select
        public List<Makes> GetMakes()
        {
            List<Makes> listMakes = new List<Makes>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakesSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Makes currentRow = new Makes()
                        {
                            MakeID = (int)dr["MakeId"],
                            MakeType = dr["MakeType"].ToString(),
                            DateAdd = Convert.ToDateTime(dr["DateAdded"]),
                            UserID = Convert.ToInt32(dr["UserID"]),
                            UserEmail = dr["Email"].ToString()


                        };
                        listMakes.Add(currentRow);
                    }
                }
                return listMakes;
            }
        }
        //get all models from modelSelect
        public List<Models> GetModels()
        {
            List<Models> listModels = new List<Models>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ModelsSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Models currentRow = new Models()
                        {
                            ModelID = (int)dr["ModelId"],
                            ModelType = dr["ModelType"].ToString(),
                            MakeID = (int)dr["MakeID"]
                        };
                        listModels.Add(currentRow);
                    }
                }
                return listModels;
            }
        }
        //get new vehicles
        public List<VehicleDisplay> GetNew()
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetNew"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg"
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }
        public List<Sales> GetPurchases()
        {
            throw new NotImplementedException();
        }
        //get specials and featured vehicles
        public SpecialAndFeatured GetSpecialAndFeatured()
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            List<Specials> listSpecials = new List<Specials>();
            SpecialAndFeatured SpecialsAndFeatured = new SpecialAndFeatured();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetFeatured"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "/Images/inventory-" + dr["VehicleId"].ToString() + ".jpg",
                            Description = dr["Description"].ToString()
                        };
                        listVehicles.Add(currentRow);
                    }
                }
                SqlCommand cmd1 = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SpecialsGetAll"
                };
                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials()
                        {
                            SpecialID = (int)dr["SpecialsId"],
                            SpecialType = dr["SpecialType"].ToString(),
                            UserID = (int)dr["UserId"]
                        };
                        listSpecials.Add(currentRow);
                    }
                }
            }
            SpecialsAndFeatured.Specials = listSpecials;
            SpecialsAndFeatured.Featured = listVehicles;
            return SpecialsAndFeatured;
        }
        //get all specials
        public List<Specials> GetSpecials()
        {
            {
                List<Specials> listSpecials = new List<Specials>();
                Specials allSpecial = new Specials();
                using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "SpecialsGetAll"
                    };
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Specials currentRow = new Specials()
                            {
                                SpecialID = (int)dr["SpecialsId"],
                                SpecialType = dr["SpecialType"].ToString(),
                                SpecialDescription = dr["SpecialDescription"].ToString(),
                                UserID = (int)dr["UserId"]
                            };
                            listSpecials.Add(currentRow);
                        }
                    }
                }
                return listSpecials;
            }
        }
        //get all used vehicles from vehicle display (names)
        public List<VehicleDisplay> GetUsed()
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetUsed"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg",
                            Description = dr["Description"].ToString()
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }
        //vehicle search
        public List<VehicleDisplay> SearchVehicles(Search sItem)
        {
            List<VehicleDisplay> listVehicles = new List<VehicleDisplay>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesSearch"
                };
                cmd.Parameters.AddWithValue("@MakeModelYear", sItem.searchItem);
                cmd.Parameters.AddWithValue("@minPrice", sItem.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", sItem.maxPrice);
                cmd.Parameters.AddWithValue("@minYear", sItem.minYear);
                cmd.Parameters.AddWithValue("@maxYear", sItem.maxYear);
                cmd.Parameters.AddWithValue("@searchType", sItem.searchType);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDisplay currentRow = new VehicleDisplay()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelType = dr["ModelType"].ToString(),
                            BodyStyleType = dr["BodyStyleType"].ToString(),
                            CarColor = dr["CarColor"].ToString(),
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorColor = dr["InteriorColor"].ToString(),
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionType = dr["TransmissionType"].ToString(),
                            Featured = (bool)dr["Featured"],
                            MakeType = dr["MakeType"].ToString(),
                            ImageName = "inventory-" + dr["VehicleId"].ToString() + ".jpg",
                            Description = dr["Description"].ToString()
                        };
                        listVehicles.Add(currentRow);
                    }
                }
            }
            return listVehicles;
        }

        // makemodels vm used to get all makes when we want to add a new model
        public List<MakeModel> GetMakeModels()
        {
            List<MakeModel> listMakeModels = new List<MakeModel>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakesModelsSelect"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModel currentRow = new MakeModel()
                        {
                            Make = dr["MakeType"].ToString(),
                            Model = dr["ModelType"].ToString(),
                            DateAdd = Convert.ToDateTime(dr["DateAdded"].ToString()),
                            UserEmail = dr["Model_Email"].ToString()

                        };
                        listMakeModels.Add(currentRow);
                    }
                }
                return listMakeModels;
            }
        }
        //get specific vehicle by id
        public Vehicles GetVehicleById(int id)
        {
            Vehicles vehicle = new Vehicles();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "VehiclesGetByID"
                };
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles currentRow = new Vehicles()
                        {
                            VehicleID = (int)dr["VehicleId"],
                            Year = (int)dr["Year"],
                            ModelID = (int)dr["ModelID"],
                            BodyStyleID = (int)dr["BodyStyleID"],
                            ColorID = (int)dr["ColorID"],
                            Mileage = (int)dr["Mileage"],
                            VIN = dr["VIN"].ToString(),
                            InteriorID = (int)dr["InteriorID"],
                            SalePrice = (decimal)dr["SalePrice"],
                            MSRP = (decimal)dr["MSRP"],
                            TransmissionID = (int)dr["TransmissionID"],
                            Featured = (bool)dr["Featured"],
                            Description = dr["Description"].ToString()
                        };
                        vehicle = currentRow;
                    }
                }
            }
            return vehicle;
        }
        //get whole inventory
        public List<vehicleInventory> GetInventory(Boolean newUsed)
        {
            List<vehicleInventory> listInventory = new List<vehicleInventory>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InventoryReport"
                };
                cmd.Parameters.AddWithValue("@Type", newUsed);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicleInventory currentRow = new vehicleInventory()
                        {
                            Year = dr["Year"].ToString(),
                            Make = dr["MakeType"].ToString(),
                            Model = dr["ModelType"].ToString(),
                            Count = dr["Count"].ToString(),
                            StockValue = dr["StockValue"].ToString(),
                        };
                        listInventory.Add(currentRow);
                    }
                }
                return listInventory;
            }
        }
        //get our makes by our modelid
        public Makes GetMakeByModelId(int ModelId)
        {
            Makes make  = new Makes();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakesByModelId"
                };
                cmd.Parameters.AddWithValue("@ModelId", ModelId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Makes currentRow = new Makes()
                        {
                            MakeID = (int)dr["MakeId"],
                            MakeType = dr["MakeType"].ToString()
                          
                        };
                        make = currentRow;
                    }
                }
            }
            return make;
        }
        //Admin edit vehicle
        public VehicleDisplay EditVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public List<SalesItems> getSalesSearch(string UserName, string from, string to)
        {
            List<SalesItems> sItems = new List<SalesItems>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SalesSearch"
                };
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@FromDate", from);
                cmd.Parameters.AddWithValue("@ToDate", to);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesItems currentRow = new SalesItems()
                        {
                            User = dr["UserName"].ToString(),
                            TotalSales = dr["TotalSales"].ToString(),
                            TotalVehicles = dr["TotalVehicles"].ToString()


                        };
                        sItems.Add(currentRow);
                    }
                }
            }
            return sItems;
        }

         
    }
}
