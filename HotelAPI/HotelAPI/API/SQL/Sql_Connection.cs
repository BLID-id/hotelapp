using Npgsql;
using DotNetEnv;

namespace HotelAPI.API.SQL;

public class SqlConnection
{
    public static NpgsqlConnection GetConnection()
    {
        string envPath = Path.Combine(Directory.GetCurrentDirectory(), "Database.env");
        Env.Load(envPath);
        
        string host = Env.GetString("DB_HOST");
        string port = Env.GetString("DB_PORT");
        string database = Env.GetString("DB_NAME");
        string username = Env.GetString("DB_USER");
        string password = Env.GetString("DB_PASSWORD");
        
        var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";

        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}