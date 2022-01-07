using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AgjensioniUdhetimit_ProjektiTI2.Models;


namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class BookingService
    {
        #region GetAllBookings
        public static List<Booking> GetAllBookings()
        {
            try
            {
                List<Booking> bookings = new List<Booking>();
                DataTable dataTable = new DataTable();

                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowBookingsList", DatabaseConnection.sqlConnection);
                    DatabaseConnection.sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Booking booking = new Booking
                            (
                             (int)row["BookingID"],
                             row["FirstName"].ToString(),
                             row["LastName"].ToString(),
                             row["Email"].ToString(),
                             row["GoingFrom"].ToString(),
                             row["GoingTo"].ToString(),
                             (DateTime)row["ArrivalDate"],
                             (DateTime)row["DepartureDate"],
                             (int)row["NOPeople"]
                            );
                        bookings.Add(booking);
                    }
                    return bookings;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public void Insert(Booking booking)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_InsertBooking", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", booking.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", booking.LastName); ;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Email", booking.Email);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@GoingFrom", booking.GoingFrom);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@GoingTo", booking.GoingTo);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@ArrivalDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@DepartureDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@NOPeople", booking.NOPeople);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@InsertBy", 1);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@InsertDate", DateTime.Now);
                    DatabaseConnection.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(Booking booking)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_EditBooking", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", booking.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", booking.LastName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Email", booking.Email);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@GoingFrom", booking.GoingFrom);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@GoingTo", booking.GoingTo);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@ArrivalDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@DepartureDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@NOPeople", booking.NOPeople);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateBy", 1);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateNumber", 1);

                    DatabaseConnection.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete
        public void Delete(int? bookingID)
        {
            try
            {
                if (bookingID != null || bookingID > 0)
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlConnection.Open();
                        DatabaseConnection.cmd = new SqlCommand("usp_DeleteBooking", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DatabaseConnection.cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        DatabaseConnection.cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

     

        public Booking GetBookingById(int id)
        {
            try
            {
                Booking booking = new Booking();
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();

                    using (DatabaseConnection.cmd = new SqlCommand("usp_GetBookingByID", DatabaseConnection.sqlConnection))
                    {
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = DatabaseConnection.cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                booking.BookingID = (int)reader["BookingID"];
                                booking.FirstName = reader["FirstName"].ToString();
                                booking.LastName = reader["LastName"].ToString();
                                booking.Email = reader["Email"].ToString();
                                booking.GoingFrom = reader["GoingFrom"].ToString();
                                booking.GoingTo = reader["GoingTo"].ToString();
                                booking.ArrivalDate = (DateTime)reader["ArrivalDate"];
                                booking.DepartureDate = (DateTime)reader["DepartureDate"];
                                booking.NOPeople = (int)reader["NOPeople"];
                            }
                        }
                    }
                }
                return booking;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}