using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Reponses.Organizations;

public class OrganizationListResponse
{
    [JsonPropertyName("organizations")]
    public List<OrganizationReponse> Organizations { get; set; }
}

public class OrganizationReponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("official_site")]
    public string OfficialSite { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public int Phone { get; set; }
}
