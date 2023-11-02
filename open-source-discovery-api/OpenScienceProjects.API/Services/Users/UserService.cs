using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Data.Repositories.Users;
using OpenScienceProjects.API.Data.Repositories.UserTags;
using OpenScienceProjects.API.Domain.Models.Users;
using OpenScienceProjects.API.Domain.Reponses.Users;
using OpenScienceProjects.API.Domain.Entities;
using OpenScienceProjects.API.Tools.JwtUtils;

namespace OpenScienceProjects.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTagRepository _userTagRepository;
        private readonly IJwtUtils _jwtUtils;

        public UserService(
            IUserRepository userRepository,
            IUserTagRepository userTagRepository,
            IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _userTagRepository = userTagRepository;
            _jwtUtils = jwtUtils;
        }

        public async Task CreateUser(UserCreateModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Password = model.Password,
                Description = model.Description,
            };

            await _userRepository.InsertOne(user);

            var userTags = model.UserTags.Select(x => new UserTag
            {
                User = user,
                TagId = x,
            });

            await _userTagRepository.InsertMany(userTags);
        }

        public async Task<string> LoginUser(UserLoginModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                throw new InvalidCredentialException();
            }
            return _jwtUtils.GenerateToken(user);
        }
        
        public int? ValidateUserToken(string token)
        {
            return _jwtUtils.ValidateToken(token);
        }

        public async Task<UserListByEmailResponse> GetUserListByEmail(string email)
        {
            var users = await _userRepository.GetUserByEmail(email);

            return new UserListByEmailResponse
            {
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                BirthDate = users.BirthDate,
                Description = users.Description,
            };
        }

        public async Task<UserListByIdResponse> GetUserListById(int id)
        {
            var users = await _userRepository.GetUserListById(id);

            return new UserListByIdResponse
            {
                Id = users.Id,
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                BirthDate = users.BirthDate,
                Description = users.Description,
            };
        }

        public async Task<UserListByNameResponse> GetUserListByName(string name)
        {
            var users = await _userRepository.GetUserListByName(name);

            return new UserListByNameResponse
            {
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                BirthDate = users.BirthDate,
                Description = users.Description,
            };
        }

        public async Task<UserListTagsByIdResponse> GetUserListTagsByUserId(int userId)
        {
            var tags = await _userTagRepository.GetTagsByUserId(userId);

            return new UserListTagsByIdResponse
            {
                Tags = tags
                    .Select(x => new UserListTagsByIdResponse.UserListTagsResponse
                    {
                        Id = x.Id,
                        Description = x.Description,
                    })
                    .ToList(),
            };
        }
    }

}
