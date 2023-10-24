using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Npgsql;


class Note
{
  public static async Task CreateNote()
  {
    var connectionString = "Host=localhost;Port=8080;Username=postgres;Password=example;Database=mydatabase";
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();
    Console.WriteLine("Que voulez-vous noter ? ");
    var prompt = Console.ReadLine();

    var sql = "INSERT INTO cnotes (contenu) VALUES (@content)";
    await using var command = new NpgsqlCommand(sql, connection);
    command.Parameters.AddWithValue("content", prompt);
    await command.ExecuteNonQueryAsync();
    Console.WriteLine("Note ajoutée avec succès !");

  }
  public static async Task ListNote()
  {
    var connectionString = "Host=localhost;Port=8080;Username=postgres;Password=example;Database=mydatabase";
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();
    Console.WriteLine("Vos notes");

    var sql = "SELECT * from cnotes";
    await using var command = new NpgsqlCommand(sql, connection);
    await using var reader = await command.ExecuteReaderAsync();
    while (await reader.ReadAsync())
    {
      Console.WriteLine($"{reader["id"]} - {reader["contenu"]}");
    }
  }

}