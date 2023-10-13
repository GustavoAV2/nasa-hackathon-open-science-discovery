using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Reponses.Projects;

public class ProjectListResponse
{
    [JsonPropertyName("projects")]
    public IList<ProjectList> Projects { get; set; }
}

public class ProjectList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public int OrganizationId { get; set; }
    public IList<string> TagDescriptions { get; set; }
}