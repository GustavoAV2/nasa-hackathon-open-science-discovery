using Microsoft.EntityFrameworkCore;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Domain.Models.Users;

namespace OpenScienceProjects.API.Data.Repositories.ProjectsTags;

public class TagRepository : ITagRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Tag> _entity;

    public TagRepository(DatabaseContext context)
    {
        _context = context;
        _entity = _context.Set<Tag>();
    }

    public Task<List<Tag>> GetAll()
    {
        return _entity.ToListAsync();
    }

    public async Task InsertMany(IEnumerable<Tag> tags)
    {
        await _entity.AddRangeAsync(tags);
        await _context.SaveChangesAsync();
    }
}