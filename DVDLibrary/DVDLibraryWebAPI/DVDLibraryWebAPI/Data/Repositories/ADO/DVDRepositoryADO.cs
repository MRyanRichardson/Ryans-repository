using DVDLibraryWebAPI.Data;
using DVDLibraryWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace DVDLibraryWebAPI.Models.Data.ADO
{   // ADO DATA
    //From DVDLibrary 2
    public class DvdRepositoryADO : IDvdRepository
    //interface methods
    {
        public void Delete(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DVD Add(DVD dvd)
        {
            
            DVD dvdOut = new DVD();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.director);
                cmd.Parameters.AddWithValue("@RatingName", dvd.rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                SqlParameter parameter = new SqlParameter("@Identity", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvdOut = currentRow;
                    }
                }
                return dvdOut;
            }
        }
        public void Update(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                DVD dvdOut = new DVD();
                SqlCommand cmd = new SqlCommand("DVDEdit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.director);
                cmd.Parameters.AddWithValue("@RatingName", dvd.rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvdOut = currentRow;
                    }
                }
                return;
            }
        }
        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectById"
                };
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
        public DVD GetById(int id)
        {
            DVD dvd = new DVD();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectById"
                };
                cmd.Parameters.AddWithValue("@DvdId", id);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvd = currentRow;
                    }
                }
            }
            return dvd;
        }
        public List<DVD> SearchByDirector(string directorName)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectByDirector"
                };
                cmd.Parameters.AddWithValue("@DirectorName", directorName);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
        public List<DVD> SearchByTitle(string title)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectBytitle"
                };
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                    return dvds;
                }
            }
        }
        public List<DVD> SearchByReleaseYear(int year)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectByreleaseYear"
                };
                cmd.Parameters.AddWithValue("@releaseYear", year);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                    return dvds;
                }
            }
        }
        public List<DVD> SearchByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DVDSelectByRating"
                };
                cmd.Parameters.AddWithValue("@RatingName", rating);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD()
                        {
                            dvdId = (int)dr["DvdId"],
                            title = dr["Title"].ToString(),
                            director = dr["DirectorName"].ToString(),
                            rating = dr["RatingName"].ToString(),
                            realeaseYear = (int)dr["RealeaseYear"],
                            notes = dr["Notes"].ToString()
                        };
                        if (dr["Notes"] != DBNull.Value)
                            currentRow.notes = dr["Notes"].ToString();
                        dvds.Add(currentRow);
                    }
                    return dvds;
                }
            }
        }
    }
}