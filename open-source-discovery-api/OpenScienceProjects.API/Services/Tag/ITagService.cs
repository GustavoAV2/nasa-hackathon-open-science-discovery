using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Domain.Models.Users;

namespace OpenScienceProjects.API.Services;

public interface ITagService
{
    Task InsertTags(TagsCreateModel tag);
    Task<List<Tag>> GetTags();
}