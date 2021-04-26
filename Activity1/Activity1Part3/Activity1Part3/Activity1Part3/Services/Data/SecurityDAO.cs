using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Do work here; connection closed on following line.
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Users WHERE USERNAME = " + user.Username + " AND PASSWORD = " + user.Password, connection))
                // TODO: Fix - SQL Thinks the model props are column names...
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Return successful if any lines exist
                    while (reader.Read())
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}