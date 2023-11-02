using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Tools.JwtUtils;

public interface IJwtUtils
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}
