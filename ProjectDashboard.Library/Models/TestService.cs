using CommunityToolkit.Mvvm.Input;

namespace ProjectDashboard.Library.Models;

public partial class TestService : Integrated
{
    public TestService()
    {
    }

    public TestService(string name)
    {
        ProjectName = name;
    }

    [ICommand]
    public override void Start()
    {
    }

    [ICommand]
    public override void Stop()
    {
    }
}