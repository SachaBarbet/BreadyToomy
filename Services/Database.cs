using System.Data.SqlClient;

namespace BreadyToomys.Services
{
    internal class Database
    {
        SqlConnection connection;
        const string connectionString = "Server=LAPTOP-E1TB3H3Q\\SQLEXPRESS02;Database=bready_tommys;Trusted_Connection=True;";
        private Database()
        {
            connection = new SqlConnection(connectionString);
        }

        private static Database instance;

        public static Database GetInstance()
        {
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public SqlCommand query(string query)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            connection.Close();
            return command;
        }

        public SqlCommand queryWithValues(string query, object[] values)
        {
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            for (int i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue($"@{i}", values[i]);
            }

            command.ExecuteNonQuery();

            connection.Close();
            return command;
        }
    }
}