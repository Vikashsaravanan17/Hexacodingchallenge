using System;
using System.Data.SqlClient;

namespace CareerHub.util
{
    public class DBConnUtil
    {
        private static readonly string connectionString =
            "Server=VIKASH\\MSSQLSERVER1;Database=CareerHubDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database connection error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
                throw;
            }
        }
    }
}
