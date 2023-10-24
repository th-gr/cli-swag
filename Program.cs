using System;

class Program
{
  static async Task Main(string[] args)
  {
    bool exit = false;
    while (!exit)
    {
      Console.Write("Entrez une option (correct, translate, create-vite ,exit, create-note, check-note) : ");
      string choice = Console.ReadLine(); // Lis l'input de l'utilisateur
      switch (choice)
      {
        case "correct":
          Console.WriteLine("Écrivez votre phrase à corriger");
          await CommandCorrect.correction();
          break;
        case "translate":
          Console.WriteLine("Traduction");
          await CommandCorrect.translate();
          break;
        case "create-vite":
          Console.WriteLine("Vite Project creation");
          await Project.createVite();
          break;
        case "create-note":
          Console.WriteLine("Création de notes");
          await Note.CreateNote();
          break;
        case "check-note":
          Console.WriteLine("Voici vos notes : ");
          await Note.ListNote();
          break;
        case "exit":
          exit = true;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
      Console.WriteLine();
    }
  }
}