using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
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
         var hosts = new[] { "yandex.ru", "vk.com", "gosuslugi.ru", "sberbank.ru", "vtb.ru", "ozon.ru", "wildberries.ru", "avito.ru", "rutube.ru", "2gis.ru", "rzd.ru", "pochta.ru", "ria.ru", "rbc.ru", "gismeteo.ru" };
        
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