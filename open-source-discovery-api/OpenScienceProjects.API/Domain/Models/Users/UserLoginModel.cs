using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Models.Users;

public class UserLoginModel
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}