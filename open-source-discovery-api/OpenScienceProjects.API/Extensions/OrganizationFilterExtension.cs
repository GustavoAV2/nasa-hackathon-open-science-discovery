using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using OpenScienceProjects.API.Domain.Entities;

namespace OpenScienceProjects.API.Extensions;

public static class OrganizationFilterExtension
{
    public static IQueryable<Organization> FilterNameNoContains(this DbSet<Organization> organization, string text)
    {
        return text.IsNullOrEmpty() ? organization.Where(x => true) : organization.Where(o => !o.Name.Contains(text));
    }
}