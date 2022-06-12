namespace ProjectDashboard.Library.ViewModels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;
using ProjectDashboard.Library.Models;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Standalone> _standalones;
    [ObservableProperty] private ObservableCollection<Integrated> _integrated;
    private bool _startsWithWindows;

    public bool StartsWithWindows 
    { 
        get => _startsWithWindows;
        set 
        {
            if (_startsWithWindows != value)
            {
                _startsWithWindows = value;
                RegistryHelper.StartWithWindows(value);
                OnPropertyChanged(nameof(StartsWithWindows));
            }            
        }
    }

    public MainWindowViewModel()
    {
        _standalones = new ObservableCollection<Standalone>();
        _integrated = new ObservableCollection<Integrated>();
        _startsWithWindows = RegistryHelper.StartsWithWindows();

        LoadStandalones().ConfigureAwait(false);
    }

    private async Task LoadStandalones()
    {
        var projects = await SettingsManager.GetStandalonesAsync();

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
            await SettingsManager.SaveStandaloneProjectsAsync(Standalones);
        }
    }

    public async Task RemoveStandalone(Standalone standalone)
    {
        if (Standalones.Any(x => x.Equals(standalone)))
        {
            Standalones.Remove(standalone);
            await SettingsManager.SaveStandaloneProjectsAsync(Standalones);
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
            await SettingsManager.SaveStandaloneProjectsAsync(Standalones);
        }
    }
}