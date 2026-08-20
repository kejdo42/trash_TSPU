using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
public class testnetwork
{
public string pinghost { get; private set; }
public bool ipconnected { get; private set; }
public string myip { get; private set; }
public testnetwork()
{
    refresh();
}
public void refresh()
{
 ipconnected = NetworkInterface.GetIsNetworkAvailable();
 try
 {
 using var client = new HttpClient();
 myip = client.GetStringAsync("https://api.ipify.org").GetAwaiter().GetResult().Trim();
 }
 catch
 {
 myip = "0.0.0.0";
 }
var pingHost = "8.8.8.8";   
var ping = new Ping();
var reply = ping.Send(pingHost);
 pinghost = reply.RoundtripTime.ToString();
}
}