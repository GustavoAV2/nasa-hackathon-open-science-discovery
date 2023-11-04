using OpenScienceProjects.API.Data.Repositories.ProjectsTags;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Domain.Models.Users;

namespace OpenScienceProjects.API.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<List<Tag>> GetTags()
    {
        return await _tagRepository.GetAll();
    }

    public async Task InsertTags(TagsCreateModel tagsCreateModel)
    {
        var tags = tagsCreateModel.Tags.Select(t => new Tag() { Description = t.Description });
        await _tagRepository.InsertMany(tags);
    }
}