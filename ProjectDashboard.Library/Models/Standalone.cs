namespace ProjectDashboard.Library.Models;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

public partial class Standalone : Project
{
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

    public Standalone(string name)
    {
        ProjectName = name;
    }

    public Standalone()
    {
    }

    [ICommand]
    public void OpenPublished()
    {
        OpenExe(PublishPath);
    }

    [ICommand]
    public void OpenDebug()
    {
        OpenExe(DebugPath);
    }

    [ICommand]
    public void OpenRelease()
    {
        OpenExe(ReleasePath);
    }

    public void OpenExe(string path)
    {
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            Process.Start(path);
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Standalone other)
        {
            return false;
        }

        if (ProjectName == other.ProjectName
            || (PublishPath == other.PublishPath &&
                (!string.IsNullOrEmpty(PublishPath) || !string.IsNullOrEmpty(other.PublishPath)))
            || (DebugPath == other.DebugPath &&
                (!string.IsNullOrEmpty(DebugPath) || !string.IsNullOrEmpty(other.DebugPath)))
            || (ReleasePath == other.ReleasePath &&
                (!string.IsNullOrEmpty(ReleasePath) || !string.IsNullOrEmpty(other.ReleasePath)))
            || (SolutionPath == other.SolutionPath &&
                (!string.IsNullOrEmpty(SolutionPath) || !string.IsNullOrEmpty(other.SolutionPath))))
        {
            return true;
        }

        return false;
    }

    public Standalone Clone()
    {
        return new Standalone
        {
            ProjectName = ProjectName,
            PublishPath = PublishPath,
            DebugPath = DebugPath,
            ReleasePath = ReleasePath,
            SolutionPath = SolutionPath
        };
    }
}