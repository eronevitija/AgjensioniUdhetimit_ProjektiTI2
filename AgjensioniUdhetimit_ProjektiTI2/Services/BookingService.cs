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
        public DataTable GetAllBookings()
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowBookingsList", DatabaseConnection.connString);
                    DataTable dataTable = new DataTable();
                    DatabaseConnection.sqlDataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region InsertBooking
        public bool InsertBooking(Booking booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertBooking", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    cmd.Parameters.AddWithValue("@ClientID", booking.ClientID);
                    cmd.Parameters.AddWithValue("@InsertBy", 1);
                    cmd.Parameters.AddWithValue("@InsertDate", booking.InsertDate);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region DeleteBooking
        public bool DeleteBooking(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("usp_DeleteBooking", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingID", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region EditBooking
        public bool EditBooking(Booking booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_EditBooking", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RezervimiID", booking.BookingID);
                    cmd.Parameters.AddWithValue("@Emri", booking.BookingDate);
                    cmd.Parameters.AddWithValue("@NumriTelefonit", booking.ClientID);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", 1);
                    cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LastUpdateNumber", booking.LastUpdateNumber);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region GetBookingByID
        public Booking GetBookingByID(int id)
        {
            DataSet ds;
            Booking booking;

            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_GetBookingByID", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                    DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter(DatabaseConnection.cmd);
                    ds = new DataSet();
                    DatabaseConnection.sqlDataAdapter.Fill(ds);
                    string bookingID = Convert.ToString(ds.Tables[0].Rows[0]["BookingID"]);
                    string bookingDate = Convert.ToString(ds.Tables[0].Rows[0]["BookingDate"]);
                    string clientID = Convert.ToString(ds.Tables[0].Rows[0]["ClientID"]);

                   booking = new Booking(Int32.Parse(bookingID),Convert.ToDateTime(bookingDate), Int32.Parse(clientID));

                    return booking;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }
}