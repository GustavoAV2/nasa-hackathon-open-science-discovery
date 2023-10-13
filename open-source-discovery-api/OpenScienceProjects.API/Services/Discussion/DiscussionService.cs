using OpenScienceProjects.API.Data.Repositories.Discussions;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services;

public class DiscussionService : IDiscussionService
{
    private readonly IDiscussionRepository _discussionRepository;

    public DiscussionService(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<List<Discussion>> GetDiscussionByProjectId(int projectId)
    {
        return await _discussionRepository.GetDiscussionListByProjectId(projectId);
    }
}