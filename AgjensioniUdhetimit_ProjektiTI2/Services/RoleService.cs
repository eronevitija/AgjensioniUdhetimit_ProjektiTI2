using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AgjensioniUdhetimit_ProjektiTI2.Models;

namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class RoleService
    {

  //      public bool InsertRole(Role role)
  //      {
		//	try
		//	{
		//		using (SqlConnection conn = new SqlConnection(DatabaseConnection.connString))
		//		{
		//			conn.Open();
		//			SqlCommand cmd = new SqlCommand("usp_InsertRole", conn);
		//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
		//			cmd.Parameters.AddWithValue("@RoleDescription", role.RoleDescription);
		//			cmd.Parameters.AddWithValue("@InsertBy", role.InsertBy);
		//			cmd.Parameters.AddWithValue("@InsertDate", role.InsertDate);
		//			cmd.ExecuteNonQuery();
		//		}
		//		return true;

		//	}
		//	catch (Exception)
		//	{
		//		throw;
		//	}
  //      }

		//public static int GetRoleID(string username,string password)
		//{
		//	try
		//	{
		//		using (DatabaseConnection.sqlConnection = new SqlConnection(DatabaseConnection.connString))
		//		{
		//			DatabaseConnection.sqlConnection.Open();
		//			SqlCommand cmd = new SqlCommand("usp_LoginRole", DatabaseConnection.sqlConnection);
		//			cmd.Parameters.AddWithValue("@Username", username);
		//			cmd.Parameters.AddWithValue("@Password", password);
		//			int result = (int)cmd.ExecuteScalar();
		//			return result;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}



    }
}