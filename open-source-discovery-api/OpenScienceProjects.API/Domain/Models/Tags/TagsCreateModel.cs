using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Models.Users;

public class TagsCreateModel
{
    [JsonPropertyName("tags")]
    public IEnumerable<TagModel> Tags { get; set; }

}

public class TagModel
{
    [JsonPropertyName("description")]
    public string Description { get; set; }
}