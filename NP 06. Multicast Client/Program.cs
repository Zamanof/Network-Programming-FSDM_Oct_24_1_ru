using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

// Смогу ли я сам получить мултикаст сообщения
client.MulticastLoopback = true;

var ip = IPAddress.Parse("224.0.0.1");
var endPoint = new IPEndPoint(ip, 27001);

List<string> messages = [
    @"/\_______",
    @"_/\______",
    @"__/\_____",
    @"___/\____",
    @"____/\___",
    @"_____/\__",
    @"______/\_",
    @"_______/\",
    @"________/",
    @"_________",
    @"\________",
    ];

var i = 0;
byte[] bytes = default!;

while (true)
{
    bytes = Encoding.UTF8.GetBytes(messages[i++ % messages.Count]);
    client.Send(bytes, bytes.Length, endPoint);
    Thread.Sleep(100);
}
