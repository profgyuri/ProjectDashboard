using Newtonsoft.Json;
using ProjectDashboard.Library.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjectDashboard.Library.Data;

/// <summary>
///     Class used to handle application resources.
/// </summary>
public static class SettingsManager
{
    private const string _jsonForStandalones = "standalones.json";
    private const string _jsonForIntegrated = "integrated.json";

    /// <summary>
    ///     Gets the standalone projects from the json file.
    /// </summary>
    /// <returns>List of <see cref="Standalone" /> objects.</returns>
    public static async Task<IEnumerable<Standalone>> GetStandalonesAsync()
    {
        var text = await File.ReadAllTextAsync(_jsonForStandalones);
        var result = JsonConvert.DeserializeObject<IEnumerable<Standalone>>(text);

        return result ?? new List<Standalone>();
    }

    /// <summary>
    ///     Gets the integrated projects from the json file.
    /// </summary>
    /// <returns>List of <see cref="Integrated" /> objects.</returns>
    public static async Task<IEnumerable<Integrated>> GetIntegratedProjectsAsync()
    {
        var text = await File.ReadAllTextAsync(_jsonForIntegrated);
        var resultSet = JsonConvert.DeserializeObject<IEnumerable<Integrated>>(text);

        if (resultSet is null)
        {
            return new List<Integrated>();
        }

        foreach (var integrated in resultSet)
        {
            if (integrated.Status is ServiceStatus.Running)
            {
                integrated.Status = ServiceStatus.Stopped;
                integrated.Start();
            }
        }

        return resultSet;
    }

    /// <summary>
    ///     Saves the list of standalone projects.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    public static async Task SaveStandaloneProjectsAsync(IEnumerable<Standalone> projects)
    {
        await using var stream = File.Create(_jsonForStandalones);
        await JsonSerializer.SerializeAsync(stream, projects, projects.GetType());
    }

    /// <summary>
    ///     Saves the list of integrated projects.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    public static async Task SaveIntegratedProjectsAsync(IEnumerable<Integrated> projects)
    {
        await using var stream = File.Create(_jsonForIntegrated);
        await JsonSerializer.SerializeAsync(stream, projects, projects.GetType());
    }
}