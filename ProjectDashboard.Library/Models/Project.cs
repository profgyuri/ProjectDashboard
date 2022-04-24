namespace ProjectDashboard.Library.Models;

public class Project
{
    /// <summary>
    ///     Name of the project.
    /// </summary>
    public string ProjectName { get; set; }

    /// <summary>
    ///     Path to the published build.
    /// </summary>
    public string PublishPath { get; set; }

    /// <summary>
    ///     Path to the debug build.
    /// </summary>
    public string DebugPath { get; set; }

    /// <summary>
    ///     Path to the release build.
    /// </summary>
    public string ReleasePath { get; set; }

    /// <summary>
    ///     Path to the solution file.
    /// </summary>
    public string SolutionPath { get; set; }

    public Project(string name)
    {
        ProjectName = name;
    }

    public Project()
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Project other)
        {
            return false;
        }

        if (ProjectName == other.ProjectName
            || PublishPath == other.PublishPath &&
            (!string.IsNullOrEmpty(PublishPath) || !string.IsNullOrEmpty(other.PublishPath))
            || DebugPath == other.DebugPath &&
            (!string.IsNullOrEmpty(DebugPath) || !string.IsNullOrEmpty(other.DebugPath))
            || ReleasePath == other.ReleasePath &&
            (!string.IsNullOrEmpty(ReleasePath) || !string.IsNullOrEmpty(other.ReleasePath))
            || SolutionPath == other.SolutionPath &&
            (!string.IsNullOrEmpty(SolutionPath) || !string.IsNullOrEmpty(other.SolutionPath)))
        {
            return true;
        }

        return false;
    }
}