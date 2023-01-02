namespace ProjectDashboard.Lib.Services;

public interface IStarterService
{
    /// <summary>
    ///     Opens the solution in the specified IDE.
    /// </summary>
    /// <param name="name">Name of the project to open.</param>
    /// <param name="ide">The IDE to open the project in.</param>
    Task OpenSolutionAsync(
        string name,
        Ide ide);

    /// <summary>
    ///     Opens the specified executable if it exists.
    /// </summary>
    /// <param name="name">Name of the project of the executable to open.</param>
    /// <param name="exe">The type of executable to open.</param>
    Task RunExecutableAsync(
        string name,
        ExecutionMode exe);
}