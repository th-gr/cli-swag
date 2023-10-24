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

    Console.WriteLine("Noter une catégorie ? ne rien mettre si vous voulez pas de catégorie");
    var cat_prompt = Console.ReadLine();

    var sql = "INSERT INTO cnotes (contenu, category) VALUES (@content, @cate)";
    await using var command = new NpgsqlCommand(sql, connection);
    command.Parameters.AddWithValue("content", prompt);
    command.Parameters.AddWithValue("cate", cat_prompt);
    await command.ExecuteNonQueryAsync();
    Console.WriteLine("Note ajoutée avec succès !");

  }
  public static async Task ListNote()
  {
    var connectionString = "Host=localhost;Port=8080;Username=postgres;Password=example;Database=mydatabase";
    await using var connection = new NpgsqlConnection(connectionString);
    await connection.OpenAsync();
    Console.Write("Vos notes par catégorie ? (o/n)");
    var filterByCategory = Console.ReadLine()?.ToLower() == "o";
    if (filterByCategory)
    {
      Console.WriteLine("Quel catégorie ?");
      var category = Console.ReadLine();
      var sql = "SELECT * FROM cnotes WHERE category = @category";
      await using var command = new NpgsqlCommand(sql, connection);
      command.Parameters.AddWithValue("category", category);
      await using var reader = await command.ExecuteReaderAsync();
      while (await reader.ReadAsync())
      {
        Console.WriteLine($"{reader["id"]} - {reader["contenu"]} - {reader["category"]}");
      }
    }
    else
    {
      var sql = "SELECT * from cnotes";
      await using var command = new NpgsqlCommand(sql, connection);
      await using var reader = await command.ExecuteReaderAsync();
      while (await reader.ReadAsync())
      {
        Console.WriteLine($"{reader["id"]} - {reader["contenu"]}");
      }
    }



  }

}