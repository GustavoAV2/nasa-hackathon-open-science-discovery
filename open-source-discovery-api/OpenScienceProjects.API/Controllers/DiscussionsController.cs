using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscussionsController : ControllerBase
{
    private readonly IDiscussionService _discussionService;

    public DiscussionsController(IDiscussionService discussionService)
    {
        _discussionService = discussionService;
    }

    [HttpGet("{projectId}")]
    public async Task<List<Discussion>> GetDiscussionByProjectId([FromRoute] int projectId)
    {
        return await _discussionService.GetDiscussionByProjectId(projectId);
    }
}