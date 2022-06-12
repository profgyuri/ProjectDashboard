namespace ProjectDashboard.Library.Data;
using Newtonsoft.Json;
using ProjectDashboard.Library.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

/// <summary>
///     Class used to handle application resources.
/// </summary>
public static class SettingsManager
{
    private const string _jsonForStandalones = "standalones.json";

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
    ///     Saves the list of standalone projects.
    /// </summary>
    /// <param name="projects">The list of projects to save.</param>
    public static async Task SaveStandaloneProjectsAsync(IEnumerable<Standalone> projects)
    {
        await using var stream = File.Create(_jsonForStandalones);
        await JsonSerializer.SerializeAsync(stream, projects, projects.GetType());
    }
}