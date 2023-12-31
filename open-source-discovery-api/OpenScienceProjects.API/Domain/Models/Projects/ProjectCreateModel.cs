﻿using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Models.Projects;

public class ProjectCreateModel
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }

    [JsonPropertyName("organization_id")]
    public int OrganizationId { get; set; }

    [JsonPropertyName("tag_ids")]
    public List<int> TagIds { get; set; } = new List<int>();
}