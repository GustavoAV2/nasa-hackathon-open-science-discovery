using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Domain.Models.Users;

namespace OpenScienceProjects.API.Data.Repositories.ProjectsTags;

public interface ITagRepository
{
    Task InsertMany(IEnumerable<Tag> tags);

    Task<List<Tag>> GetAll();
}