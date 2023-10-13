using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Models.Projects;
using OpenScienceProjects.API.Domain.Models.Users;
using OpenScienceProjects.API.Domain.Reponses.Projects;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public Task<ProjectListResponse> GetProjectList([FromQuery] UserTagsListModel userTagsListModel)
    {
        return _projectService.GetProjectList(userTagsListModel.TagIds);
    }

    [HttpGet("organization/{organizationId}")]
    public Task<List<ProjectListByIdResponse>> GetProjectByOrganizationId(int organizationId)
    {
        return _projectService.GetProjectListByOrganizationId(organizationId);
    }

    [HttpGet("name/{name}")]
    public Task<List<ProjectListByIdResponse>> GetProjectByName(string name)
    {
        return _projectService.GetProjectListByName(name);
    }

    [HttpGet("{id}")]
    public Task<ProjectListByIdResponse> GetProjectListById(int id)
    {
        return _projectService.GetProjectListById(id);
    }
    
    [HttpGet("/tags/{id}")]
    public Task<List<int>> GetProjectTagsByProjectId(int id)
    {
        return _projectService.GetProjectTagByIdProjectId(id);
    }

    [HttpPost]
    public Task CreateProject(ProjectCreateModel projectCreateModel)
    {
        return _projectService.CreateProject(projectCreateModel);
    }

    [HttpPost("users")]
    public Task AddUserToProject(ProjectAddUserModel projectAddUserModel)
    {
        return _projectService.AddUserToProject(projectAddUserModel);
    }
}