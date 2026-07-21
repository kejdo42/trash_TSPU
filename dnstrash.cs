using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
public class dnstrash
{
    public bool stopdns = false;
    public string resp { get; private set; }
    public string responsehtml { get; private set; }
   
    public dnstrash()
    
    {

    }
    public async Task initAsync()
    {
       await  refresh();
    }
   async Task refresh()
    {
       var random = new Random();
        string hostName = "ya.ru";
          
                    for(;;)
        {   
    if(stopdns == false)
    {
         int randomSize = random.Next(300, 700);
      IPAddress[] addresses = await Dns.GetHostAddressesAsync(hostName);
      if (addresses.Length > 0)
    resp = "OK";
else
    resp = "No DNS";
            await Task.Delay(randomSize);
            
        }
        else
        {
            break;
        }
    }
}
}   
