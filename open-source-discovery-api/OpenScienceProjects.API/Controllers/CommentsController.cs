using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet("{discussionId}")]
    public async Task<List<Comment>> GetCommentListByProjectId([FromRoute] int discussionId)
    {
        return await _commentService.GetCommentListByProjectId(discussionId);
    }
}