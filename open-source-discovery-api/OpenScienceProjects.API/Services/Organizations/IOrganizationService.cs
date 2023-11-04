using OpenScienceProjects.API.Domain.Models.Organizations;
using OpenScienceProjects.API.Domain.Reponses.Organizations;

namespace OpenScienceProjects.API.Services
{
    public interface IOrganizationService
    {
        Task<int> CreateOrganization(OrganizationCreateModel model);
        Task<OrganizationListResponse> GetOrganizations();
        Task<OrganizationListByIdResponse> GetOrganizationListById(int id);
        Task<OrganizationListTagsByIdResponse> GetOrganizationListTagsById(int organizationId);
    }
}
