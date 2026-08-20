using Avalonia.Controls;
using System.Threading.Tasks;

namespace trash_TSPU_GUI;

public partial class MainWindow : Window
{
    testnetwork _networkLogic = new testnetwork();
    trash _trashLogic = new trash();
    httptrash _httpLogic = new httptrash();
    dnstrash _dnsLogic = new dnstrash();
    public MainWindow()
    {
        InitializeComponent();
    }
    async public void OnStartClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
{
     _ = _trashLogic.initAsync();
        _ = _httpLogic.initAsync();
        _ = _dnsLogic.initAsync();
        _trashLogic.stoptrash = (trash.IsChecked == false);
        _httpLogic.stophttp = (trashhttp.IsChecked == false);
        _dnsLogic.stopdns = (dnstrash.IsChecked == false);
        while(true)
        {
            _networkLogic.refresh();
            var logtext =
            "ping to "+ _networkLogic.pinghost + "ms\n " +
            "My IP: " + _networkLogic.myip + "\n" +
            "Network connected:"  + _networkLogic.ipconnected + "\n" +
            "Ping to " + _trashLogic.pinghost + ": " + (_trashLogic.stoptrash ? "stopped" : _trashLogic.mc + " ms") + "\n" +
            "http status: " + (_httpLogic.stophttp ? "stopped" : _httpLogic.resp) + "\n" +
            "dns status: " + (_dnsLogic.stopdns ? "stopped" : _dnsLogic.hostName + ": " + _dnsLogic.resp) + "\n";
            log.Text = logtext;
            await Task.Delay(150);

        }
}
}