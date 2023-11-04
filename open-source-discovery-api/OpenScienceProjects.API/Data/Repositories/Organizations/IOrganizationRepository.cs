using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Repositories.Organizations;

public interface IOrganizationRepository
{
    Task<int> InsertOne(Organization organization);
    Task<Organization> GetOrganizationListById(int id);
    Task<List<Organization>> GetAllOrganizations();
}