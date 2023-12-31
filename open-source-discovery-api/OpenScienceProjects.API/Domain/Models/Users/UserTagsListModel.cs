﻿#nullable enable
using System.Text.Json.Serialization;

namespace OpenScienceProjects.API.Domain.Models.Users;

public class UserTagsListModel
{
    [JsonPropertyName("tagIds")]
    public List<int>? TagIds { get; set; }
}