using System.Diagnostics;
using ProjectDashboard.Lib.Repositories;

namespace ProjectDashboard.Lib.Services;

public sealed class StarterService : IStarterService
{
    private readonly ISolutionRepository _solutionRepository;

    public StarterService(ISolutionRepository solutionRepository)
    {
        _solutionRepository = solutionRepository;
    }
    
    #region Implementation of IStarterService
    /// <inheritdoc />
    public async Task OpenSolutionAsync(
        string name,
        Ide ide)
    {
        var solution = await _solutionRepository.GetByNameAsync(name)!;
        
        switch (ide)
        {
            case Ide.VisualStudio:
                OpenSolution("devenv.exe");
                break;
            case Ide.Rider:
                OpenSolution("rider64.exe");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ide), ide, null);
        }
        
        void OpenSolution(string path)
        {
            if (!File.Exists(solution.SolutionPath) || !solution.SolutionPath.EndsWith(".sln"))
            {
                return;
            }
            
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                Arguments = $"\"{solution.SolutionPath}\"",
                UseShellExecute = true
            });
        }
    }

    /// <inheritdoc />
    public async Task RunExecutableAsync(
        string name,
        ExecutionMode exe)
    {
        var solution = await _solutionRepository.GetByNameAsync(name)!;
        var path = solution.ExePath;
        
        if (!File.Exists(path) || !path.EndsWith(".exe"))
        {
            return;
        }
            
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }
    #endregion
}