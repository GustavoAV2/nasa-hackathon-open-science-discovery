using OpenScienceProjects.API.Domain.Models.Projects;
using OpenScienceProjects.API.Domain.Reponses.Projects;

namespace OpenScienceProjects.API.Services
{
    public interface IProjectService
    {
        Task CreateProject(ProjectCreateModel model);
        Task AddUserToProject(ProjectAddUserModel model);
        Task<ProjectListResponse> GetProjectList(IList<int> userTagsListModel);
        Task<ProjectListByIdResponse> GetProjectListById(int id);
        Task<List<ProjectListByIdResponse>> GetProjectListByOrganizationId(int organizationId);
        Task<List<ProjectListByIdResponse>> GetProjectListByName(string name);
        Task<List<int>> GetProjectTagByIdProjectId(int id);
    }
}
