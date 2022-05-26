namespace ProjectDashboard.Library.Models;
using CommunityToolkit.Mvvm.Input;

/// <summary>
///     Class used to represent integrated projects.
/// </summary>
/// <remarks>
///     This class handles only .dll files, thus it cannot interact with a UI.
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

        OnStarting();
        OnStarted();
    }

    [ICommand]
    public void Stop()
    {
        if (Status is ServiceStatus.Stopped or ServiceStatus.Stopping)
        {
            return;
        }

        OnStopping();
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
    protected virtual void OnStarting()
    {
        Status = ServiceStatus.Starting;
    }

    /// <summary>
    ///     Called when the service is started.
    /// </summary>
    protected virtual void OnStarted()
    {
        Status = ServiceStatus.Running;
    };

    /// <summary>
    ///     Called to stop the service.
    /// </summary>
    protected virtual void OnStopping()
    {
        Status = ServiceStatus.Stopping;
    }

    /// <summary>
    ///     Called when the service is stopped.
    /// </summary>
    protected virtual void OnStopped()
    {
        Status = ServiceStatus.Stopped;
    }
}