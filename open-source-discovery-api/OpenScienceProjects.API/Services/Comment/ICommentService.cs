using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services;

public interface ICommentService
{
    Task<List<Comment>> GetCommentListByProjectId(int discussionId);
}