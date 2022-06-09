namespace ProjectDashboard.Library.Models;

public class TestService : Integrated
{
    public TestService()
    {
        ProjectName = GetType().Name;
    }

    public TestService(string name)
    {
        ProjectName = name;
    }

    protected override void OnStarted()
    {
        ProjectName = "Onstarted";
    }

    protected override void OnStarting()
    {
        ProjectName = "OnStarting";
    }

    protected override void OnStopped()
    {
        ProjectName = "OnStopped";
    }

    protected override void OnStopping()
    {
        ProjectName = "OnStopping";
    }
}