﻿using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Data.Repositories.Discussions;

public interface IDiscussionRepository
{
    Task<List<Discussion>> GetDiscussionListByProjectId(int projectId);
}