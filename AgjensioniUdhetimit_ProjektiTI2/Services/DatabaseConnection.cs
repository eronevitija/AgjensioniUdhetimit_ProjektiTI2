using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AgjensioniUdhetimit_ProjektiTI2.Services
{
    public class DatabaseConnection
    {
        //Add the connection string inside the Web.config file, see example for "DefaultConnection"
        
        public static string connString = ConfigurationManager.ConnectionStrings["agjensioniConnection"].ConnectionString.ToString();


        //Add needed stuff to connect with the database

        public static SqlConnection sqlConnection;
        public static SqlCommand cmd;
        public static SqlDataAdapter sqlDataAdapter;






    }
}