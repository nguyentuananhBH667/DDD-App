using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOCERY
{
    public class DatabaseConnection
    {
        public static string _connectionString = "Data Source=LAPTOP-G8O5NSJ7;Initial Catalog=GLOCERY;Integrated Security=True;TrustServerCertificate=True";

    public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
            }
            catch
            {
                MessageBox.Show("Error while connecting to the database", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return connection;
        }
    }

}
