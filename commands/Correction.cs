using System;
using System.Net.Http;
using System.Threading.Tasks;
using OpenAI_API;
using dotenv.net;

class CommandCorrect
{
  public static async Task correction()
  {
    var api = new OpenAI_API.OpenAIAPI("ma-cle");
    Console.Write("Écrivez votre phrase : ");
    var prompt = Console.ReadLine();
    var result = await api.Completions.GetCompletion("Corrige cette phrase : " + prompt);
    Console.WriteLine(result);

  }
  public static async Task translate()
  {
    var api = new OpenAI_API.OpenAIAPI("ma-cle");
    Console.Write("Écrivez votre phrase : ");
    var prompt = Console.ReadLine();
    Console.Write("Choissisez une langue : ");
    var langPrompt = Console.ReadLine();
    var result = await api.Completions.GetCompletion("Traduis moi cette phrase en " + langPrompt + "voici la phrase :" + prompt);
    Console.WriteLine(result);
  }
}