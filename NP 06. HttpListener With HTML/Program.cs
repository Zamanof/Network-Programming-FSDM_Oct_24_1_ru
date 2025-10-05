using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add(@"http://localhost:27001/");
listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    var login = request.QueryString["login"];
    var password = request.QueryString["password"];
    StreamWriter streamWriter = new(response.OutputStream);
    Console.WriteLine(HttpMethod.Get.Method);

    if (request.HttpMethod == HttpMethod.Get.Method)
    {
        if (IsAuthorized(login!, password!))
        {
            streamWriter.Write($"<h1 style='color:blue;'>Welcome {login}</h1>");
        }
        else
        {
            streamWriter.Write($"<h1 style='color:red;'>Incorrect login or password</h1>");
        }
    }
    else if (request.HttpMethod == HttpMethod.Post.Method)
    {
        Console.WriteLine("This is post method");
    }


    streamWriter.Close();
}

bool IsAuthorized(string login, string password)
{
    if (login == "admin" && password == "admin") return true;
    return false;
}
