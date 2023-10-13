using OpenScienceProjects.API.Data.Repositories.Comments;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<Comment>> GetCommentListByProjectId(int discussionId)
    {
        return await _commentRepository.GetCommentListByProjectId(discussionId);
    }

}