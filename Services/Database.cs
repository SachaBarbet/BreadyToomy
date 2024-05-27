using Npgsql;

namespace BreadyToomys.Services
{
    public class Database
    {
        NpgsqlConnection connection;
        const string connectionString = "Host=localhost;Username=postgres;Password=12345;Database=postgres";

        // Singleton
        private Database()
        {
            connection = new NpgsqlConnection(connectionString);
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

        public NpgsqlCommand query(string query)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            return command;
        }

        public NpgsqlCommand queryWithValues(string query, object[] values)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            for (int i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue($"@{i}", values[i]);
            }

            command.ExecuteNonQuery();
            return command;
        }

        public void close()
        {
            connection.Close();
        }
    }
}