using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;
using ProjectDashboard.Library.Models;

namespace ProjectDashboard.Library.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Project> _standalones;
    [ObservableProperty] private ObservableCollection<Project> _integrated;

    public MainWindowViewModel()
    {
        _standalones = new ObservableCollection<Project>();
        _integrated = new ObservableCollection<Project>();

        LoadStandalones().ConfigureAwait(false);
    }

    private async Task LoadStandalones()
    {
        var projects = await SettingsManager.GetProjectsAsync();

        Standalones.Clear();

        foreach (var project in projects)
        {
            Standalones.Add(project);
        }
    }

    [ICommand]
    public async Task AddStandalone(Project project)
    {
        if (project is null)
        {
            return;
        }

        if (!Standalones.Any(x => x.Equals(project)))
        {
            Standalones.Add(project);
            await SettingsManager.SaveProjectsAsync(Standalones);
        }
    }
}