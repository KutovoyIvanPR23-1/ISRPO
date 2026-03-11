using System.Configuration;
using System.Data.SqlClient;

public static class DatabaseHelper
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
    }
}