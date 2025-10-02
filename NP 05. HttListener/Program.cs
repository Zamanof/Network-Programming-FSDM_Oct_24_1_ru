using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add(@"http://localhost:27001/");
listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request);
    //Console.WriteLine(request.RawUrl);
    // ?login=mr.13&password=123456 - query string (?key1=value1&key2=value2&...)
    //var rawUrl = request.RawUrl;
    //var queryString = rawUrl.Split('?')[1];
    ////Console.WriteLine(queryString);
    //var strings = queryString.Split('&');
    //for (int i = 0; i < strings.Length; i++)
    //{
    //    var data = strings[i].Split('=');
    //    Console.WriteLine($"key={data[0]} - value = {data[1]}");
    //}

    //Console.WriteLine(request.QueryString);

    //foreach (string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"key={key} -> value={request.QueryString[key]}");
    //}
    //response.AddHeader("Content-Type", "text/plain");
    //response.AddHeader("Content-Type", "text/html");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.Write($"Salam {request.QueryString["login"]}");
    var login = request.QueryString["login"];
    writer.WriteLine("<h1 style='color: red;'>Salam</h1>");
    writer.WriteLine(@$"<a href='https://www.google.com/search?q={login}'>Search</a>");
    writer.WriteLine(@"<img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>");

    writer.Close();
}
