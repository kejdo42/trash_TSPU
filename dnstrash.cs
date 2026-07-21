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
    public string hostName { get; private set; }
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
         var hosts = new[] { "yandex.ru", "vk.com", "gosuslugi.ru", "sberbank.ru", "vtb.ru", "ozon.ru", "wildberries.ru", "avito.ru", "rutube.ru", "2gis.ru", "rzd.ru", "pochta.ru", "ria.ru", "rbc.ru", "gismeteo.ru" };
         
                    for(;;)
        {   
    if(stopdns == false)
    {
         int randomSize = random.Next(300, 700);
         this.hostName = hosts[random.Next(hosts.Length)];
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
