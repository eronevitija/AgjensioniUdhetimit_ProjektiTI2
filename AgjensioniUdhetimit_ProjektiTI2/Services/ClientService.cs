using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AgjensioniUdhetimit_ProjektiTI2.Models;



namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class ClientService 
    { 

        #region GetAllClient

        public DataTable GetAllClient()
        {
                try
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowClientList", DatabaseConnection.connString);
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

        #region InsertClient
        public bool InsertClient(Client client)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_InsertClient", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", client.LastName);
                        cmd.Parameters.AddWithValue("@Address", client.Address);
                        cmd.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", client.Email);
                        //cmd.Parameters.AddWithValue("@InsertBy", client.InsertBy);
                        //cmd.Parameters.AddWithValue("@InsertDate", client.InsertDate);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                return false;
                }
            }
            #endregion

        #region DeleteClient
            public bool DeleteClient(int id)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("usp_DeleteClient", sqlConnection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", id);
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

        #region UpdateClient
            public bool UpdateClient(Client client)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_EditClient", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                        cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", client.LastName);
                        cmd.Parameters.AddWithValue("@Address", client.Address);
                        cmd.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", client.Email);
                        cmd.Parameters.AddWithValue("@LastUpdateBy", 1);
                        cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LastUpdateNumber", client.LastUpdateNumber);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            #endregion
        
        #region GetClientByID
            public Client GetClientByID(int id)
            {
                DataSet ds;
                Client client;

                try
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlConnection.Open();
                        DatabaseConnection.cmd = new SqlCommand("usp_GetClientByID", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                        DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                        DatabaseConnection.sqlDataAdapter = new SqlDataAdapter(DatabaseConnection.cmd);
                        ds = new DataSet();
                        DatabaseConnection.sqlDataAdapter.Fill(ds);
                        string clientID = Convert.ToString(ds.Tables[0].Rows[0]["ClientID"]);
                        string firstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                        string lastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                        string address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                        string phoneNumber = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNumber"]);
                        string email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);

                        client = new Client(Int32.Parse(clientID), firstName, lastName, address, Int32.Parse(phoneNumber), email);

                        return client;

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