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
        var solution = await _solutionRepository.GetByNameAsync(name);
        
        switch (ide)
        {
            case Ide.VisualStudio:
                break;
            case Ide.Rider:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ide), ide, null);
        }
    }

    /// <inheritdoc />
    public async Task RunExecutableAsync(
        string name,
        ExecutionMode exe)
    {
        switch (exe)
        {
            case ExecutionMode.Debug:
                break;
            case ExecutionMode.Release:
                break;
            case ExecutionMode.Published:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(exe), exe, null);
        }
    }
    #endregion
}