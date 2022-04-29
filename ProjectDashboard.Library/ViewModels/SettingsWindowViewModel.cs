using CommunityToolkit.Mvvm.ComponentModel;
using ProjectDashboard.Library.Models;

namespace ProjectDashboard.Library.ViewModels;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private Project _projectObject;

    public SettingsWindowViewModel()
    {
        ProjectObject = new Project();
    }
}