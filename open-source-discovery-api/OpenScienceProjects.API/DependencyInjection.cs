using Microsoft.EntityFrameworkCore;
using OpenScienceProjects.API.Data;
using OpenScienceProjects.API.Data.Repositories.Comments;
using OpenScienceProjects.API.Data.Repositories.Discussions;
using OpenScienceProjects.API.Data.Repositories.Organizations;
using OpenScienceProjects.API.Data.Repositories.Projects;
using OpenScienceProjects.API.Data.Repositories.ProjectsTags;
using OpenScienceProjects.API.Data.Repositories.ProjectsUsers;
using OpenScienceProjects.API.Data.Repositories.Users;
using OpenScienceProjects.API.Data.Repositories.UserTags;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API;

public static class DependencyInjection
{
    public static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IOrganizationRepository, OrganizationRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IProjectTagRepository, ProjectTagRepository>();
        services.AddTransient<IProjectUserRepository, ProjectUserRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserTagRepository, UserTagRepository>();
        services.AddTransient<IDiscussionRepository, DiscussionRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IProjectService, ProjectService>();
        services.AddTransient<IOrganizationService, OrganizationService>();
        services.AddTransient<IDiscussionService, DiscussionService>();
        services.AddTransient<ICommentService, CommentService>();
    }
}