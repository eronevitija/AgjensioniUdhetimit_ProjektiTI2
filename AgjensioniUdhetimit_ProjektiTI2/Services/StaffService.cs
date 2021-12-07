using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AgjensioniUdhetimit_ProjektiTI2.Models;


namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class StaffService
    {
        #region GetStaff
        public DataTable GetStaff()
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowStafList", DatabaseConnection.connString);
                    DataTable dTable = new DataTable();
                    DatabaseConnection.sqlDataAdapter.Fill(dTable);
                    return dTable;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region InsertStaff
        public bool InsertStaff(Staff staff)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertStaff", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    cmd.Parameters.AddWithValue("@@LastName", staff.LastName);
                    cmd.Parameters.AddWithValue("@Gender", staff.Gender);
                    cmd.Parameters.AddWithValue("@Address", staff.Address);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Birthdate", staff.Birthdate);
                    cmd.Parameters.AddWithValue("@InsertBy", staff.InsertBy);
                    cmd.Parameters.AddWithValue("@InsertDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
        #endregion

        #region DeleteStaff
        public bool DeleteStaff(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_DeleteStaff", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StaffID", id);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region EditStaff
        public bool EditStaff(Staff staff)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_EditStaff", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StafiID", staff.StaffID);
                    cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                    cmd.Parameters.AddWithValue("@Gender", staff.Gender);
                    cmd.Parameters.AddWithValue("@Address", staff.Address);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Birthdate", staff.Birthdate);

                    cmd.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region GetItemByID
        public Staff GetItemById(int id)
        {
            DataSet ds;
            Staff staff;

            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_GetStaffByID", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                    DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter(DatabaseConnection.cmd);

                    ds = new DataSet();
                    DatabaseConnection.sqlDataAdapter.Fill(ds);

                    string staffID = Convert.ToString(ds.Tables[0].Rows[0]["StaffID"]);
                    string firtName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    string lastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    string gender = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                    string address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    string email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    string phoneNumber = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);
                    string birthDate = Convert.ToString(ds.Tables[0].Rows[0]["Birthdate"]);

                    staff = new Staff(Int32.Parse(staffID),firtName,lastName,char.Parse(gender),address,email
                        ,Int32.Parse(phoneNumber),DateTime.Parse(birthDate));
                    return staff;
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