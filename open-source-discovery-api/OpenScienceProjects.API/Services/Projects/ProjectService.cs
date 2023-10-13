using OpenScienceProjects.API.Data.Repositories.Projects;
using OpenScienceProjects.API.Data.Repositories.ProjectsTags;
using OpenScienceProjects.API.Data.Repositories.ProjectsUsers;
using OpenScienceProjects.API.Domain.Models.Projects;
using OpenScienceProjects.API.Domain.Reponses.Projects;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTagRepository _projectTagRepository;
        private readonly IProjectUserRepository _projectUserRepository;

        public ProjectService(
            IProjectRepository projectRepository,
            IProjectTagRepository projectTagRepository,
            IProjectUserRepository projectUserRepository)
        {
            _projectRepository = projectRepository;
            _projectTagRepository = projectTagRepository;
            _projectUserRepository = projectUserRepository;
        }

        public async Task CreateProject(ProjectCreateModel model)
        {
            var project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                Link = model.Link,
                OrganizationId = model.OrganizationId,
            };

            await _projectRepository.InsertOne(project);

            var projectTags = model.TagIds.Select(x => new ProjectTag
            {
                Project = project,
                TagId = x,
            });

            await _projectTagRepository.InsertMany(projectTags);
        }

        public Task AddUserToProject(ProjectAddUserModel model)
        {
            var projectUser = new ProjectUser
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
            };

            return _projectUserRepository.InsertOne(projectUser);
        }

        public async Task<ProjectListResponse> GetProjectList(IList<int> userTagsListModel)
        {
            if (userTagsListModel == null || !userTagsListModel.Any())
            {
                var projects = await _projectRepository.GetProjectListIfTagsIsEmpty();
                return new ProjectListResponse
                {
                    Projects = projects
                };
            }
            else
            {
                var projects = _projectRepository.GetProjectList(userTagsListModel);

                return new ProjectListResponse
                {
                    Projects = projects.ToList()
                };
            }
        }

        public async Task<ProjectListByIdResponse> GetProjectListById(int id)
        {
            var projects = await _projectRepository.GetProjectListById(id);

            return new ProjectListByIdResponse
            {
                Id = projects.Id,
                Title = projects.Title,
                Description = projects.Description,
                Link = projects.Link,
                OrganizationId = projects.OrganizationId,
                TagDescriptions = projects.ProjectTags.Select(x => x.Tag.Description).ToList()
            };
        }

        public async Task<List<ProjectListByIdResponse>> GetProjectListByOrganizationId(int organizationId)
        {
            var projects = await _projectRepository.GetProjectListByOrganizationId(organizationId);

            return projects.Select(p =>
                new ProjectListByIdResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Link = p.Link,
                    OrganizationId = p.OrganizationId
                }).ToList();
        }

        public async Task<List<ProjectListByIdResponse>> GetProjectListByName(string name)
        {
            var projects = await _projectRepository.GetProjectListByName(name);

            return projects.Select(p => new ProjectListByIdResponse
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Link = p.Link,
                OrganizationId = p.OrganizationId
            }).ToList();
        }

        public async Task<List<int>> GetProjectTagByIdProjectId(int id)
        {
            var projectTags = await _projectRepository.GetProjectTagsByIdProjectId(id);
            return projectTags.Select(x => x.TagId).ToList();
        }
    }
}
