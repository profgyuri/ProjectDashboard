using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;

namespace ProjectDashboard.Library.Models;

public abstract partial class Project
{
    /// <summary>
    ///     Name of the project.
    /// </summary>
    public string ProjectName { get; set; }

    /// <summary>
    ///     Path to the solution file.
    /// </summary>
    public string SolutionPath { get; set; }

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
}