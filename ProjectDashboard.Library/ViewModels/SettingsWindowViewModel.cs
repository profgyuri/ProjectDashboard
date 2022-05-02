using CommunityToolkit.Mvvm.ComponentModel;
using ProjectDashboard.Library.Models;

namespace ProjectDashboard.Library.ViewModels;

public partial class SettingsWindowViewModel : ObservableObject
{
    [ObservableProperty] private Standalone _standaloneObject;

    public SettingsWindowViewModel()
    {
        StandaloneObject = new Standalone();
    }

    public void UpdateUI()
    {
        OnPropertyChanged(nameof(StandaloneObject));
    }
}