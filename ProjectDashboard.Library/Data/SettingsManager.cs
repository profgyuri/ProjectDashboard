using Newtonsoft.Json;
using ProjectDashboard.Library.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjectDashboard.Library.Data;

/// <summary>
///     Class used to handle application resources.
/// </summary>
public static class SettingsManager
{
    private const string _jsonFile = "settings.json";

    /// <summary>
    ///     Gets the standalone projects from the json file.
    /// </summary>
    /// <returns>List of <see cref="Standalone" /> objects.</returns>
    public static async Task<IEnumerable<Standalone>> GetProjectsAsync()
    {
        var text = await File.ReadAllTextAsync(_jsonFile);
        var result = JsonConvert.DeserializeObject<IEnumerable<Standalone>>(text);

        return result ?? new List<Standalone>();
    }

    /// <summary>
    ///     Saves the list of standalone projects.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    public static async Task SaveProjectsAsync(IEnumerable<Standalone> projects)
    {
        await using var stream = File.Create(_jsonFile);
        await JsonSerializer.SerializeAsync(stream, projects, projects.GetType());
    }
}