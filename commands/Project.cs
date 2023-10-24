using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Project
{
  public static async Task createVite()
  {
    Console.Write("Nom du projet : ");
    var name_project = Console.ReadLine();
    var process = Process.Start("npm", "create vite@latest " + name_project);
    await process.WaitForExitAsync();
    Process.Start("code", name_project);
  }
}