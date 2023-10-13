using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services;

public interface IDiscussionService
{
    Task<List<Discussion>> GetDiscussionByProjectId(int projectId);
}