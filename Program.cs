var trash = new trash();
_ = trash.initAsync();
var httptrash = new httptrash();
_ = httptrash.initAsync();
var dnstrash = new dnstrash();
_ = dnstrash.initAsync();
while (true)
{
testnetwork testnetwork = new testnetwork();
Console.WriteLine("Ping to " + testnetwork.pinghost + " ms");
Console.WriteLine("My IP: " + testnetwork.myip);
Console.WriteLine("Network connected: " + testnetwork.ipconnected);

    while (httptrash.resp == null || dnstrash.resp == null || trash.mc == null)
{
    await Task.Delay(100);
}
Console.WriteLine("Ping to yandex.ru: " + trash.mc + " ms");
Console.WriteLine("http status: " + httptrash.resp);
Console.WriteLine("dns status: " + dnstrash.resp);
}