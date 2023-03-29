using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using ProjectDashboard.Lib.Models;
using ProjectDashboard.Lib.Notifications;
using ProjectDashboard.Lib.Repositories;
using ProjectDashboard.Lib.Services;

namespace ProjectDashboard.Lib.ViewModels;

[INotifyPropertyChanged]
public partial class MainWindowViewModel
    : INotificationHandler<NewProjectCreatedNotification>
{
    private readonly IStarterService _starterService;
    private readonly ISolutionRepository _solutionRepository;

    [ObservableProperty] private ObservableCollection<Solution> _solutions;

    public MainWindowViewModel(IStarterService starterService, ISolutionRepository solutionRepository)
    {
        _starterService = starterService;
        _solutionRepository = solutionRepository;

        _solutions = new(_solutionRepository.GetAllAsync().Result);
    }

    [RelayCommand]
    private void SolutionInVS(Solution solution)
    {
        _starterService.OpenSolution(solution, Ide.VisualStudio);
    }
    
    [RelayCommand]
    private void SolutionInRider(Solution solution)
    {
        _starterService.OpenSolution(solution, Ide.Rider);
    }
    
    [RelayCommand]
    private void RunExe(Solution solution)
    {
        _starterService.RunExecutable(solution);
    }

    Task INotificationHandler<NewProjectCreatedNotification>.Handle(NewProjectCreatedNotification notification, CancellationToken cancellationToken)
    {
        Solutions.Add(notification.Solution);
        return Task.CompletedTask;
    }
}