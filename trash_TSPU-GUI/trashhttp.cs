using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
public class httptrash
{
    public bool stophttp = false;
    public string resp { get; private set; }
    public string responsehtml { get; private set; }
    private readonly HttpClient _httpClient = new HttpClient();
    public httptrash()
     {

    }
    public async Task initAsync()
    {
       await  refresh();
    }
   async Task refresh()
    {
       var random = new Random();
      string[] hosts;
      try
      {
       _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
        string jsonText = File.ReadAllText("config/httplist.json");
        hosts = JsonSerializer.Deserialize<string[]>(jsonText);
        if(hosts == null)
        {
            resp = "ERROR";
            return;
        }
      }
      catch(Exception ex)
      {
        var pingHost = "ERROR: " + ex.Message;
         Console.WriteLine($"{pingHost}");
         return;
      }
          
                    for(;;)
        {   
    if(stophttp == false)
    {
         int randomSize = random.Next(300, 700);
         var pingHost = hosts[random.Next(hosts.Length)];
         HttpResponseMessage response;
      try
      {
       response = await _httpClient.GetAsync(pingHost);
      }
      catch(Exception ex)
      {
        resp = ex.GetType().Name;
        responsehtml = ex.Message;
        Console.WriteLine($"{responsehtml}");
        continue;
      }
     resp = response.StatusCode.ToString();
     responsehtml = await response.Content.ReadAsStringAsync();   
         if(resp == null)
      {
        resp ="ERROR";
      }   
      Console.WriteLine($"{responsehtml}");
            await Task.Delay(randomSize);        
        }
        else
        {
            break;
        }
    }
}
}   
