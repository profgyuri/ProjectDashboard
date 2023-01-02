using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Lib.Services;

namespace ProjectDashboard.Lib.ViewModels;

[INotifyPropertyChanged]
public partial class MainWindowViewModel
{
    private readonly IStarterService _starterService;
    
    [ObservableProperty] private ObservableCollection<string> _projectNames;

    public MainWindowViewModel(IStarterService starterService)
    {
        _starterService = starterService;
        _projectNames = new()
        {
            "Multitasking",
            "Music Listening",
            "Something, that is hopefully too long for 2 lines, so the text will be trimmed."
        };
    }

    [RelayCommand]
    private void SolutionInVS(string name)
    {
        _starterService.OpenSolutionAsync(name, Ide.VisualStudio);
    }
    
    [RelayCommand]
    private void SolutionInRider(string name)
    {
        _starterService.OpenSolutionAsync(name, Ide.Rider);
    }
    
    [RelayCommand]
    private void RunDebug(string name)
    {
        _starterService.RunExecutableAsync(name, ExecutionMode.Debug);
    }
    
    [RelayCommand]
    private void RunRelease(string name)
    {
        _starterService.RunExecutableAsync(name, ExecutionMode.Release);
    }
    
    [RelayCommand]
    private void RunPublished(string name)
    {
        _starterService.RunExecutableAsync(name, ExecutionMode.Published);
    }
}