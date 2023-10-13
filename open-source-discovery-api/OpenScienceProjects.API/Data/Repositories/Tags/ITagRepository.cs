using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Repositories.ProjectsTags;

public interface ITagRepository
{
    Task InsertMany(IEnumerable<Tag> projectTags);
}