using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Repositories.ProjectsTags;

public interface IProjectTagRepository
{
    Task InsertMany(IEnumerable<ProjectTag> projectTags);
}