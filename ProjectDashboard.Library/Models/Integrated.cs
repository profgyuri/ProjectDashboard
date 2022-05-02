using CommunityToolkit.Mvvm.Input;

namespace ProjectDashboard.Library.Models;

/// <summary>
///     Class used to represent integrated projects.
/// </summary>
/// <remarks>
///     This class handles only .dll files, thus it cannot interact with a UI.
///     <para />
///     The starting mechanism should be exposed, or if the provided service is not <see cref="IDisposable" />,
///     then the stopping mechanism too.
/// </remarks>
/// <example>
///     <code>
///        public class MyService : Integrated
///       {
///            ...
///       }
/// 
///       var project = new MyService();
///       project.Start(); //to start the service
///       project.Stop(); //to stop the service
///     </code>
/// </example>
public abstract partial class Integrated : Project
{
    protected Integrated()
    {
    }

    protected Integrated(string name)
    {
        ProjectName = name;
    }

    [ICommand]
    public abstract void Start();

    [ICommand]
    public abstract void Stop();
}