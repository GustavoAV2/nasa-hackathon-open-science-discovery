using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Domain.Models.Users;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost("")]
    public Task InsertTags(TagsCreateModel createTagsModel)
    {
        return _tagService.InsertTags(createTagsModel);
    }

    [HttpGet("")]
    public Task<List<Tag>> GetTags()
    {
        return _tagService.GetTags();
    }
}