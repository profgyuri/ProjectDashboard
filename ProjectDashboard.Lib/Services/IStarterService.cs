namespace ProjectDashboard.Lib.Services;

using ProjectDashboard.Lib.Models;

public interface IStarterService
{
    /// <summary>
    ///     Opens the solution in the specified IDE.
    /// </summary>
    /// <param name="name">Name of the project to open.</param>
    /// <param name="ide">The IDE to open the project in.</param>
    void OpenSolution(
        Solution solution,
        Ide ide);

    /// <summary>
    ///     Opens the specified executable if it exists.
    /// </summary>
    /// <param name="name">Name of the project of the executable to open.</param>
    /// <param name="exe">The type of executable to open.</param>
    void RunExecutable(Solution solution);
}