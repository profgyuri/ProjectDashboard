using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;
using ProjectDashboard.Library.Models;

namespace ProjectDashboard.Library.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Standalone> _standalones;
    [ObservableProperty] private ObservableCollection<Integrated> _integrated;

    public MainWindowViewModel()
    {
        _standalones = new ObservableCollection<Standalone>();
        _integrated = new ObservableCollection<Integrated>();

        _integrated.Add(new TestService("Test 1"));

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
    public async Task AddStandalone(Standalone standalone)
    {
        if (standalone is null)
        {
            return;
        }

        if (!Standalones.Any(x => x.Equals(standalone)))
        {
            Standalones.Add(standalone);
            await SettingsManager.SaveProjectsAsync(Standalones);
        }
    }

    public async Task RemoveStandalone(Standalone standalone)
    {
        if (Standalones.Any(x => x.Equals(standalone)))
        {
            Standalones.Remove(standalone);
            await SettingsManager.SaveProjectsAsync(Standalones);
        }
    }

    public async Task EditStandalone(Standalone old, Standalone edited)
    {
        if (old is null || edited is null)
        {
            return;
        }

        if (Standalones.Any(x => x.Equals(old)))
        {
            var oldIndex = Standalones.IndexOf(old);
            Standalones[oldIndex] = edited;
            await SettingsManager.SaveProjectsAsync(Standalones);
        }
    }
}