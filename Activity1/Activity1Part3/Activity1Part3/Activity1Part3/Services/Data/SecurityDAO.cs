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
            System.Diagnostics.Debug.WriteLine("Username: " + user.Username + " Password: " + user.Password);
            // Console.WriteLine("Username: " + user.Username + " Password: " + user.Password);
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string connectionStringTableSpecific = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionStringTableSpecific))
            {
                System.Diagnostics.Debug.WriteLine("Connection: " + connection.ToString());
               connection.Open();
                System.Diagnostics.Debug.WriteLine("Conn state: " + connection.State);
                // Do work here; connection closed on following line.
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Users WHERE USERNAME = @Username AND PASSWORD = @Password", connection))
                {
                    // Prepare statement
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        System.Diagnostics.Debug.WriteLine("Rows: " + reader.HasRows);
                        return reader.HasRows;
                        //return reader.RecordsAffected > 0;
                    }
                }
               
            }
        }
    }
}