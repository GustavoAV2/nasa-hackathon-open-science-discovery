using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Models.Organizations;
using OpenScienceProjects.API.Domain.Reponses.Organizations;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet]
    public Task<OrganizationListResponse> GetOrganizations()
    {
        return _organizationService.GetOrganizations();
    }

    [HttpPost]
    public Task<int> CreateOrganization(OrganizationCreateModel organizationCreateModel)
    {
        return _organizationService.CreateOrganization(organizationCreateModel);
    }

    [HttpGet("{id}")]
    public Task<OrganizationListByIdResponse> GetOrganizationListById(int id)
    {
        return _organizationService.GetOrganizationListById(id);
    }

    [HttpGet("{id}/tags")]
    public Task<OrganizationListTagsByIdResponse> GetOrganizationListTagsById(int id)
    {
        return _organizationService.GetOrganizationListTagsById(id);
    }
}