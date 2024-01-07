//Microsoft.Data.SqlClient

using System.Data;
using Microsoft.Data.SqlClient;

const string connectionString  = "Server=localhost,1433;Database=balta;User ID=sa;password=1q2w3e4r@#$;Encrypt=False";

using (var connection = new SqlConnection(connectionString))
{
    Console.WriteLine("Conectado");
    connection.Open();

    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT [Id], [Title] FROM [Category]";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader.GetGuid(0)} Title: {reader.GetString(1)}");
        }
    }
}
