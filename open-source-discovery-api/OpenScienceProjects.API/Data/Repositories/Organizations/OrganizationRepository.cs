using Microsoft.EntityFrameworkCore;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Extensions;

namespace OpenScienceProjects.API.Data.Repositories.Organizations;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Organization> _entity;

    public OrganizationRepository(DatabaseContext context)
    {
        _context = context;
        _entity = _context.Set<Organization>();
    }

    public async Task<int> InsertOne(Organization organization)
    {
        await _entity.AddAsync(organization);
        await _context.SaveChangesAsync();
        return organization.Id;
    }

    public Task<Organization> GetOrganizationListById(int id)
    {
        return _entity
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Organization>> GetAllOrganizations()
    {
        return await _entity.FilterNameNoContains(",").ToListAsync();
    }
}