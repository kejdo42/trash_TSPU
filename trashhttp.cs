using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
       _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
        string url = "https://ya.ru";
          
                    for(;;)
        {   
    if(stophttp == false)
    {
         int randomSize = random.Next(300, 700);
       HttpResponseMessage response = await _httpClient.GetAsync(url);
       response.EnsureSuccessStatusCode();
     resp = response.StatusCode.ToString();
     responsehtml = await response.Content.ReadAsStringAsync();   
            await Task.Delay(randomSize);
            
        }
        else
        {
            break;
        }
    }
}
}   
