using System.Text.Json.Serialization;

namespace CatsPresenter.Website.Model;

public class CatInfo
{
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("url")] 
    public string ImageUrl { get; set; } = string.Empty;
}