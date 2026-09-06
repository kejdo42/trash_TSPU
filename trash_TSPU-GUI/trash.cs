using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
public class trash
{
    public bool stoptrash = false;
    public string mc { get; private set; }
    public string pinghost { get; private set; }
    
    public trash()
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
         string jsonText = File.ReadAllText("config/iplist.json");
        hosts = JsonSerializer.Deserialize<string[]>(jsonText);
         Console.WriteLine($"{hosts.Length}");
         }
         catch (Exception ex)
    {
         pinghost = "ERROR: " + ex.Message;
         return;
    }
           using (var ping = new Ping())
           {
            int maxPacketSize = 100;
                    for(;;)
        {   
    if(stoptrash == false)
    {
       
        int randomSize = random.Next(32, maxPacketSize + 1);
         int randomSize2 = random.Next(200, 500);
           var pingHost = hosts[random.Next(hosts.Length)];
         pinghost = pingHost; 
    
         try
           {
              
               var reply = await ping.SendPingAsync(pingHost);
               mc = reply.RoundtripTime.ToString();
           }
           catch
           {
               mc = "No ping";
           }
            await Task.Delay(randomSize2);
            
        }
        else
        {
            break;
        }
    }
}
}  
} 