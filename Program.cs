var trash = new trash();
_ = trash.initAsync();
var httptrash = new httptrash();
_ = httptrash.initAsync();
var dnstrash = new dnstrash();
_ = dnstrash.initAsync();
 var testnetwork = new testnetwork();
bool testCompleted = false;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Текущие опции:");
    Console.WriteLine($"  dnstrash отключен: {(dnstrash.stopdns ? "да" : "нет")}");
    Console.WriteLine($"  httptrash отключен: {(httptrash.stophttp ? "да" : "нет")}");
    Console.WriteLine($"  trash отключен: {(trash.stoptrash ? "да" : "нет")}");
    Console.WriteLine();
    Console.WriteLine("Введите:");
    Console.WriteLine("  1 - отключить dnstrash");
    Console.WriteLine("  2 - отключить httptrash");
    Console.WriteLine("  3 - отключить trash");
    Console.WriteLine("  y - запустить тест сети");
    Console.WriteLine("  n - вернуться к выбору опций");
    Console.WriteLine("  q - выйти");

    var input = Console.ReadLine()?.Trim().ToLowerInvariant();
    if (input == "1")
    {
        dnstrash.stopdns = true;
        Console.WriteLine("dnstrash отключен.");
        continue;
    }
    if (input == "2")
    {
        httptrash.stophttp = true;
        Console.WriteLine("httptrash отключен.");
        continue;
    }
    if (input == "3")
    {
        trash.stoptrash = true;
        Console.WriteLine("trash отключен.");
        continue;
    }
    if (input == "y")
    {
        Console.WriteLine("Запускаем тест сети...");
        while (true)
        {
            testnetwork.refresh();

            if ((!httptrash.stophttp && httptrash.resp == null)
                || (!dnstrash.stopdns && dnstrash.resp == null)
                || (!trash.stoptrash && trash.mc == null))
            {
                await Task.Delay(100);
                continue;
            }

            Console.WriteLine();
            Console.WriteLine("Ping to " + testnetwork.pinghost + " ms");
            Console.WriteLine("My IP: " + testnetwork.myip);
            Console.WriteLine("Network connected: " + testnetwork.ipconnected);

            Console.WriteLine("Ping to " + trash.pinghost + ": " + (trash.stoptrash ? "stopped" : trash.mc + " ms"));
            Console.WriteLine("http status: " + (httptrash.stophttp ? "stopped" : httptrash.resp));
            Console.WriteLine("dns status: " + (dnstrash.stopdns ? "stopped" : dnstrash.hostName + ": " + dnstrash.resp));
        }
    }
    if (input == "n")
    {
        Console.WriteLine("Возвращаемся к выбору опций.");
        continue;
    }
    if (input == "q")
    {
        Console.WriteLine("Выход.");
        break;
    }

    Console.WriteLine("Неправильный ввод. Попробуйте снова.");
}

if (!testCompleted)
{
    Console.WriteLine("Тест сети не запущен.");
}
