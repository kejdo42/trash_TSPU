using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
public class trash
{
    public bool stoptrash = false;
    public string mc { get; private set; }
    
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
         var pingHost = "yandex.ru";
           using (var ping = new Ping())
           {
            int maxPacketSize = 100;
                    for(;;)
        {   
    if(stoptrash == false)
    {
       
        int randomSize = random.Next(32, maxPacketSize + 1);
         int randomSize2 = random.Next(200, 500);
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