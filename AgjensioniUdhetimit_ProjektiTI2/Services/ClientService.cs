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

        #region GetAllClients
        public static List<Client> GetAllClients()
        {
            try
            {
                List<Client> clients = new List<Client>();
                DataTable dataTable = new DataTable();
                using (DatabaseConnection.sqlConnection= new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowClientList", DatabaseConnection.sqlConnection);
                    DatabaseConnection.sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Client client = new Client
                            (
                                (int)row["ClientID"],
                                row["FirstName"].ToString(),
                                row["LastName"].ToString(),
                                row["Address"].ToString(),
                                (int)row["PhoneNumber"],
                                row["Email"].ToString()
                            );
                        clients.Add(client);
                    }
                    return clients;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public void Insert(Client client)
        {
               try
               {
                   using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                   {
                        DatabaseConnection.sqlConnection.Open();
                        DatabaseConnection.cmd = new SqlCommand("usp_InsertClient", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                        DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", client.LastName); 
                        DatabaseConnection.cmd.Parameters.AddWithValue("@Address", client.Address);
                        DatabaseConnection.cmd.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
                        DatabaseConnection.cmd.Parameters.AddWithValue("@Email", client.Email);
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
        public void Delete(int? clientID)
        {
            try
            {
                if (clientID != null || clientID > 0)
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlConnection.Open();

                        DatabaseConnection.cmd = new SqlCommand("usp_DeleteClient", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                        DatabaseConnection.cmd.Parameters.AddWithValue("@ClientID", clientID);
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
                    string clientID = Convert.ToString((ds.Tables[0].Rows[0]["ClientID"]));
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

        #region UpdateClient
        public void Update(Client client)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();

                    DatabaseConnection.cmd = new SqlCommand("usp_EditClient", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", client.LastName); 
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Address", client.Address);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Email", client.Email);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateNumber", 1);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateBy", 1);
                    DatabaseConnection.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        //#region SearchByNameAndAddress
        //public Client GetClientName(string name)
        //{
        //    try
        //    {
        //        Client client = new Client();
        //        using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
        //        {
        //            DatabaseConnection.sqlConnection.Open();
        //            using (DatabaseConnection.cmd = new SqlCommand("usp_SearchClient", DatabaseConnection.sqlConnection))
        //            {
        //                DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
        //                DatabaseConnection.cmd.Parameters.AddWithValue("@Name", name);

        //                using (SqlDataReader reader = DatabaseConnection.cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        client.ClientID = (int)reader["ClientID"];
        //                        client.FirstName = reader["FirstName"].ToString();
        //                        client.LastName = reader["LastName"].ToString();
        //                        client.Address = reader["Address"].ToString();
        //                        client.PhoneNumber = (int)reader["PhoneNumber"];
        //                        client.Email = reader["Email"].ToString();


        //                    }
        //                }
        //            }
        //        }
        //        return client;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion


        public Client Search(string name)
        {
            DataSet ds;
            Client client;
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_SearchClient", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Name", name);
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter(DatabaseConnection.cmd);
                    ds = new DataSet();
                    DatabaseConnection.sqlDataAdapter.Fill(ds);
                    string clientID = Convert.ToString((ds.Tables[0].Rows[0]["ClientID"]));
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
    }
}

