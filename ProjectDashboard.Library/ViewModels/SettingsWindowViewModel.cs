using CommunityToolkit.Mvvm.ComponentModel;
using ProjectDashboard.Library.Models;

namespace ProjectDashboard.Library.ViewModels;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private Project _projectObject;
    [ObservableProperty] private int _height;
    [ObservableProperty] private bool _nameFieldVisible;

    public SettingsWindowViewModel()
    {
        ProjectObject = new Project();
    }
}