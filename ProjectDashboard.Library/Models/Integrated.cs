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
    public ServiceStatus Status { get; set; }

    [ICommand]
    public void Start()
    {
        if (Status is ServiceStatus.Running or ServiceStatus.Starting)
        {
            return;
        }

        Status = ServiceStatus.Starting;
        OnStarting();
        Status = ServiceStatus.Running;
        OnStarted();
    }

    [ICommand]
    public void Stop()
    {
        if (Status is ServiceStatus.Stopped or ServiceStatus.Stopping)
        {
            return;
        }

        Status = ServiceStatus.Stopping;
        OnStopping();
        Status = ServiceStatus.Stopped;
        OnStopped();
    }

    [ICommand]
    public void Restart()
    {
        Stop();
        Start();
    }

    /// <summary>
    ///     Called to start the service.
    /// </summary>
    protected abstract void OnStarting();

    /// <summary>
    ///     Called when the service is started.
    /// </summary>
    protected abstract void OnStarted();

    /// <summary>
    ///     Called to stop the service.
    /// </summary>
    protected abstract void OnStopping();

    /// <summary>
    ///     Called when the service is stopped.
    /// </summary>
    protected abstract void OnStopped();
}