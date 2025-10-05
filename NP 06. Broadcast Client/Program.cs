using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

client.EnableBroadcast = true;

var endPoint = new IPEndPoint(IPAddress.Parse("10.2.11.255"), 27001);

List<string> messages = [
        @"|",
        @"/",
        @"-",
        @"\"
    ];

int i = 0;
int length = messages.Count;
int minutes = 0;
int seconds = 0;
var stopWatch = string.Empty; 
while (true)
{
    //var data = Encoding.UTF8.GetBytes(messages[i++ % length]);
    //client.Send(data, data.Length, endPoint);
    if(seconds == 60)
    {
        seconds = 0;
        minutes++;
    }
    if (seconds <= 9) stopWatch = $"0{minutes}:0{seconds}";
    else stopWatch = $"0{minutes}:{seconds}";
    var data = Encoding.UTF8.GetBytes(stopWatch);
    client.Send(data, data.Length, endPoint);

    Thread.Sleep(1000);
    seconds++;
}


