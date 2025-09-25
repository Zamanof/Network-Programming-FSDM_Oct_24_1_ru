using System.Net;
using System.Net.Sockets;
using System.Text;

Socket client = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);
var message = """
    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque quis sapien ac leo malesuada consequat eu et nulla. Donec in enim ipsum. Duis interdum ante at justo venenatis, ac tempus ex tempor. Nulla facilisi. Integer vel eleifend lectus. Nullam sed lacus semper, efficitur nisl eget, vehicula lacus. Donec aliquam, mi in efficitur consequat, ex ante luctus orci, et vestibulum libero tortor eget dui. In pretium accumsan consectetur.
    Nullam sit amet pretium nunc, ut facilisis nulla. Proin eu gravida tellus. Mauris turpis elit, ornare at gravida eu, convallis quis nunc. Pellentesque placerat tristique leo non convallis. Aliquam pulvinar sagittis dapibus. Nulla ornare lobortis purus. Nullam vel eleifend sem, a sollicitudin felis. Quisque a enim in nisi consectetur blandit quis nec odio. Cras sit amet ipsum feugiat, condimentum mauris at, sollicitudin lectus. Aliquam purus erat, dictum vitae libero imperdiet, varius rutrum augue. Aenean imperdiet nec tortor in viverra. Ut scelerisque porttitor eros, at vestibulum dolor venenatis nec. Maecenas sagittis non ligula id dapibus. Integer gravida lectus nec lorem venenatis dignissim.
    Fusce id egestas mi. Suspendisse consequat elit sed lacus porttitor semper. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur semper lacus dui. Sed tortor arcu, posuere quis mi at, cursus dapibus nisi. Phasellus sapien augue, fermentum eget rhoncus non, euismod facilisis ipsum. Ut a lorem sit amet mauris dapibus facilisis eget quis tortor.
    Nam sagittis sapien vel aliquam fringilla. Mauris malesuada sem magna, eget porta diam fringilla nec. Vivamus vitae tellus erat. Cras felis lacus, condimentum at purus et, accumsan volutpat leo. In placerat diam non posuere aliquam. Etiam ac interdum arcu, sit amet laoreet dui. Vivamus placerat lacus a mauris sagittis, ut mattis enim consequat. Integer eu sagittis magna. Quisque mattis elit ut scelerisque ultrices. Fusce blandit tellus et est posuere, sit amet fermentum quam dapibus. Nam tincidunt leo vel rutrum lacinia. Duis et sapien sed dui mollis volutpat id eu massa. Sed ante eros, suscipit eu dictum quis, ultrices at justo. Nam sed libero eu ligula mattis dictum. Suspendisse potenti. Nullam cursus venenatis elementum.
    Nulla molestie eros non orci ornare suscipit. Vestibulum ullamcorper et lectus sit amet consequat. Maecenas a enim congue, lobortis tellus iaculis, interdum quam. Nulla condimentum velit in lectus venenatis, ut auctor erat malesuada. Mauris ultrices ipsum sapien, nec auctor erat lacinia at. Pellentesque faucibus, ex quis elementum suscipit, nibh arcu dictum lacus, a pulvinar dolor ex quis purus. Duis aliquet ex ac elementum sodales. Curabitur vehicula, neque vitae ornare tempor, sapien lectus sodales risus, ut faucibus nunc lectus vel nisi.
    """;

int count = 0;
while (true)
{
    var bytes =
        Encoding.Default.GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEp);
}

