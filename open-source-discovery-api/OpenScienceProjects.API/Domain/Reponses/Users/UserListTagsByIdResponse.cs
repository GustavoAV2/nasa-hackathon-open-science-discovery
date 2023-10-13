using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Reponses.Users;

public class UserListTagsByIdResponse
{
    [JsonPropertyName("tags")]
    public IList<UserListTagsResponse> Tags { get; set; }

    public class UserListTagsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}