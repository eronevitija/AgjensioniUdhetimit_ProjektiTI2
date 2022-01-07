using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AgjensioniUdhetimit_ProjektiTI2.Models;

namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class TicketService
    {

        #region GetAllClients
        public List<Ticket> GetAllTickets()
        {
            try
            {
                List<Ticket> tickets= new List<Ticket>();
                DataTable dataTable = new DataTable();

                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();

                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter("usp_ShowTicketList", DatabaseConnection.sqlConnection);
                    DatabaseConnection.sqlDataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Ticket ticket = new Ticket
                            (
                              (int)row["TicketID"],
                              row["FirstName"].ToString(),
                              row["LastName"].ToString(),
                              (DateTime)row["DateCreated"],
                              row["Deadline"].ToString()
                            );
                        tickets.Add(ticket);
                    }
                    return tickets;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region InsertTicket
        public void InsertTicket(Ticket ticket)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_InsertTicket", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", ticket.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", ticket.LastName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@DateCreated", ticket.DateCreated);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Deadline", ticket.Deadline);
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
        public void Update(Ticket ticket)
        {
            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();

                    DatabaseConnection.cmd = new SqlCommand("usp_EditTicket", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                    DatabaseConnection.cmd.Parameters.AddWithValue("@TicketID", ticket.TicketID);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@FirstName", ticket.FirstName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastName", ticket.LastName);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@DateCreated", ticket.DateCreated);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@Deadline", ticket.Deadline);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateNumber", 1);
                    DatabaseConnection.cmd.Parameters.AddWithValue("@LastUpdateBy", 1);

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
        public void Delete(int? ticketID)
        {
            try
            {
                if (ticketID != null || ticketID > 0)
                {
                    using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                    {
                        DatabaseConnection.sqlConnection.Open();

                        DatabaseConnection.cmd = new SqlCommand("usp_DeleteTicket", DatabaseConnection.sqlConnection);
                        DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                        DatabaseConnection.cmd.Parameters.AddWithValue("@TicketID", ticketID);
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
        public Ticket GetTicketByID(int id)
        {
            DataSet ds;
            Ticket ticket;

            try
            {
                using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
                {
                    DatabaseConnection.sqlConnection.Open();
                    DatabaseConnection.cmd = new SqlCommand("usp_GetTicketByID", DatabaseConnection.sqlConnection);
                    DatabaseConnection.cmd.CommandType = CommandType.StoredProcedure;

                    DatabaseConnection.cmd.Parameters.AddWithValue("@ID", id);
                    DatabaseConnection.sqlDataAdapter = new SqlDataAdapter(DatabaseConnection.cmd);
                    ds = new DataSet();
                    DatabaseConnection.sqlDataAdapter.Fill(ds);
                    string ticketID = Convert.ToString((ds.Tables[0].Rows[0]["TicketID"]));
                    string firstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    string lastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    string dateCreated = Convert.ToString(ds.Tables[0].Rows[0]["DateCreated"]);
                    string deadline = Convert.ToString(ds.Tables[0].Rows[0]["Deadline"]);


                    ticket = new Ticket(Int32.Parse(ticketID), firstName, lastName, Convert.ToDateTime(dateCreated), deadline);

                    return ticket;
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