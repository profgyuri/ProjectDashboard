namespace ProjectDashboard.Library.Data;

using Microsoft.EntityFrameworkCore;
using ProjectDashboard.Library.Models;

/// <summary>
///     Class used to handle application resources.
/// </summary>
public static class SettingsManager
{
    private static readonly DatabaseContext _dbContext = new();

    /// <summary>
    ///     Gets the standalone projects from the json file.
    /// </summary>
    /// <returns>List of <see cref="Standalone" /> objects.</returns>
    public static async Task<IEnumerable<Standalone>> GetStandalonesAsync()
    {
        _dbContext.Database.EnsureCreated();

        return await _dbContext.Standalones.ToListAsync();
    }

    /// <summary>
    ///     Saves the list of standalone projects.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    public static void SaveStandaloneProjects(IEnumerable<Standalone> projects)
    {
        _dbContext.Database.EnsureCreated();
        _dbContext.UpdateRange(projects);
        _dbContext.SaveChanges();
    }
}