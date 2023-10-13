using OpenScienceProjects.API.Domain.Models.Users;
using OpenScienceProjects.API.Domain.Reponses.Users;

namespace OpenScienceProjects.API.Services;

public interface IUserService
{
    Task CreateUser(UserCreateModel model);
    Task<UserListByEmailResponse> GetUserListByEmail(string email);
    Task<UserListByIdResponse> GetUserListById(int id);
    Task<UserListByNameResponse> GetUserListByName(string name);
    Task<UserListTagsByIdResponse> GetUserListTagsByUserId(int userId);
}