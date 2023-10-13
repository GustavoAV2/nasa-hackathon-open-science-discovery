using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Repositories.ProjectsUsers;

public interface IProjectUserRepository
{
    Task InsertOne(ProjectUser projectUser);
}