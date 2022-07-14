namespace ProjectDashboard.Library.Models;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Serialization;

public partial class Standalone : Project
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///     Path to the published build.
    /// </summary>
    public string PublishPath { get; set; } = string.Empty;

    /// <summary>
    ///     Path to the debug build.
    /// </summary>
    public string DebugPath { get; set; } = string.Empty;

    /// <summary>
    ///     Path to the release build.
    /// </summary>
    public string ReleasePath { get; set; } = string.Empty;

    public Standalone(string name)
    {
        ProjectName = name;
    }

    public Standalone()
    {
    }

    [RelayCommand]
    public void OpenPublished()
    {
        OpenExe(PublishPath);
    }

    [RelayCommand]
    public void OpenDebug()
    {
        OpenExe(DebugPath);
    }

    [RelayCommand]
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

    /// <summary>
    ///     Path to the solution file.
    /// </summary>
    [DataMember]
    public string SolutionPath { get; set; } = string.Empty;

    [RelayCommand]
    public void OpenInVS()
    {
        OpenSolution("devenv.exe");
    }

    [RelayCommand]
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

        ProcessStartInfo? info = new ProcessStartInfo
        {
            FileName = path,
            Arguments = "\"" + SolutionPath + "\"",
            UseShellExecute = true
        };

        Process.Start(info);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = ProjectName?.GetHashCode() + hash * 486187739 ?? hash;
            hash = DebugPath?.GetHashCode() + hash * 486187739 ?? hash;
            hash = PublishPath?.GetHashCode() + hash * 486187739 ?? hash;
            hash = ReleasePath?.GetHashCode() + hash * 486187739 ?? hash;
            hash = SolutionPath?.GetHashCode() + hash * 486187739 ?? hash;
            return hash;
        }
    }
}