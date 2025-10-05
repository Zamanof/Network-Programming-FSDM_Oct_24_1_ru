using System.Text.Json.Serialization;

class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }


    [JsonPropertyName("title")]
    public string? Name { get; set; }
    
    [JsonPropertyName("body")]
    public string? Message { get; set; }

    public override string ToString()
    {
        return $@"{Id}. Title:{Name} 
Message: {Message}";
    }
}
