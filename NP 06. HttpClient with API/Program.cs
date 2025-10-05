using System.Text.Json;

var client = new HttpClient();

var uri = "https://jsonplaceholder.typicode.com/posts";
var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(uri)
};

//var response = await client.SendAsync(message);
var response = await client.GetAsync(uri);
var json = await response.Content.ReadAsStringAsync();
//Console.WriteLine(json);
var posts = JsonSerializer.Deserialize<List<Post>>(json);

posts.ForEach(p => {
    Console.WriteLine(p);
    Console.WriteLine("\n\n");
});