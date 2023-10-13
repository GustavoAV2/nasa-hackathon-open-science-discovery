using OpenScienceProjects.API.Data.Repositories.Organizations;
using OpenScienceProjects.API.Data.Repositories.Projects;
using OpenScienceProjects.API.Domain.Models.Organizations;
using OpenScienceProjects.API.Domain.Reponses.Organizations;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IProjectRepository projectRepository, IOrganizationRepository organizationRepository)
        {
            _projectRepository = projectRepository;
            _organizationRepository = organizationRepository;
        }

        public Task<int> CreateOrganization(OrganizationCreateModel model)
        {
            var organization = new Organization
            {
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                OfficialSite = model.OfficialSite,
                Email = model.Email,
                Phone = model.Phone,
            };

            return _organizationRepository.InsertOne(organization);
        }

        public async Task<OrganizationListTagsByIdResponse> GetOrganizationListTagsById(int organizationId)
        {
            var tags = await _projectRepository.GetTagsByOrganizationId(organizationId);

            return new OrganizationListTagsByIdResponse
            {
                Tags = tags
                    .Select(x => new OrganizationListTagsByIdResponse.OrganizationListTagsResponse
                    {
                        Id = x.TagId,
                        Description = x.Tag.Description,
                    })
                    .ToList(),
            };
        }

        public async Task<OrganizationListByIdResponse> GetOrganizationListById(int id)
        {
            var organization = await _organizationRepository.GetOrganizationListById(id);

            return new OrganizationListByIdResponse
            {
                Name = organization.Name,
                Description = organization.Description,
                Location = organization.Location,
                OfficialSite = organization.OfficialSite,
                Email = organization.Email,
                Phone = organization.Phone,
            };
        }
    }
}
