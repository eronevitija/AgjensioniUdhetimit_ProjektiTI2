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
        #region GetAllStaff
        public List<Staff> GetAllStaff()
        {
            try
            {
                List<Staff> staffs = new List<Staff>();
                DataTable dataTable = new DataTable();

                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();

                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowStafList", DatabaseConnection.sqlConnection);
                    DatabaseConnection.sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Staff staff = new Staff
                            (
                              (int)row["StaffID"],
                              row["FirstName"].ToString(),
                              row["LastName"].ToString(),
                              row["Gender"].ToString(),
                              row["Address"].ToString(),
                              row["Email"].ToString(),
                              (int)row["PhoneNumber"],
                              (DateTime)row["Birthdate"]
                              );
                        staffs.Add(staff);
                    }
                    return staffs;
                }
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
                    cmd.Parameters.AddWithValue("@StaffID", staff.StaffID);
                    cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                    cmd.Parameters.AddWithValue("@Gender", staff.Gender);
                    cmd.Parameters.AddWithValue("@Address", staff.Address);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Birthdate", staff.Birthdate);
                    cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LastUpdateNumber", 1);
                    cmd.Parameters.AddWithValue("@LastUpdateBy", 1);
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

        #region Insert
        public void Insert(Staff staff)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_InsertStaff", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Gender", staff.Gender);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Address", staff.Address);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Email", staff.Email);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Birthdate", DateTime.Now);
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

        #region Delete
        public void Delete(int? staffID)
        {
            try
            {
                if (staffID != null || staffID > 0)
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlConnection.Open();
                        DatabaseConnection.cmd = new SqlCommand("usp_DeleteStaff", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DatabaseConnection.cmd.Parameters.AddWithValue("@StaffID", staffID);
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

        #region GetStaffByID
        public Staff GetStaffById(int id)
        {
            try
            {
                Staff staff = new Staff();
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    using (DatabaseConnection.cmd = new SqlCommand("usp_GetStaffByID", DatabaseConnection.sqlConnection))
                    {
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = DatabaseConnection.cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                staff.StaffID= (int)reader["StaffID"];
                                staff.FirstName = reader["FirstName"].ToString();
                                staff.LastName = reader["LastName"].ToString();
                                staff.Gender = reader["Gender"].ToString();
                                staff.Address = reader["Address"].ToString();
                                staff.Email = reader["Email"].ToString();
                                staff.PhoneNumber = (int)reader["PhoneNumber"];
                                staff.Birthdate = (DateTime)reader["Birthdate"];
                            }
                        }
                    }
                }
                return staff;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        public static bool CheckLogInConfig(string username, string password)
        {
            bool gjendja = false;
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DataTable dt = new DataTable();
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_LoginRole", DatabaseConnection.sqlConnection);
                    DatabaseConnection.sqlDataAdapter.Fill(dt);
                    string IdRecord = "";
                    string passwordi = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdRecord = dt.Rows[i][0].ToString();
                        passwordi = dt.Rows[0][1].ToString();

                        if (IdRecord.Equals(username) && passwordi.Equals(password))
                        {
                            gjendja = true;

                        }
                    }

                }
                return gjendja;
            }
            catch (Exception)
            {
                return gjendja;
            }
        }

    }
}