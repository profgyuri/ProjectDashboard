using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;

namespace ProjectDashboard.Library.Models;

public partial class Project
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

    [ICommand]
    public void OpenInVS()
    {
        OpenSolution("devenv.exe");
    }

    [ICommand]
    public void OpenInRider()
    {
        OpenSolution(RegistryHelper.GetRiderPath());
    }

    private void OpenSolution(string path)
    {
        if (string.IsNullOrEmpty(SolutionPath) || !File.Exists(SolutionPath))
        {
            return;
        }

        var info = new ProcessStartInfo
        {
            FileName = path,
            Arguments = "\"" + SolutionPath + "\"",
            UseShellExecute = true
        };

        Process.Start(info);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Project other)
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

    public Project Clone()
    {
        return new Project
        {
            ProjectName = ProjectName,
            PublishPath = PublishPath,
            DebugPath = DebugPath,
            ReleasePath = ReleasePath,
            SolutionPath = SolutionPath
        };
    }
}