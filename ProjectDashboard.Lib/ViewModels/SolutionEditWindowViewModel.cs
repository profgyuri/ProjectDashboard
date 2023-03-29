using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using ProjectDashboard.Lib.Models;
using ProjectDashboard.Lib.Notifications;
using ProjectDashboard.Lib.Repositories;

namespace ProjectDashboard.Lib.ViewModels;

[INotifyPropertyChanged]
public partial class SolutionEditWindowViewModel
{
    private readonly ISolutionRepository _solutionRepository;
    private readonly IMediator _mediator;

    [ObservableProperty] private Solution _solution;

    public bool IsEditingOnly { get; set; }

    public SolutionEditWindowViewModel(ISolutionRepository solutionRepository, IMediator mediator)
    {
        Solution = new Solution()
        {
            Name = "New Solution",
            SolutionPath = @"C:\Path\To\Your.sln"
        };
        _solutionRepository = solutionRepository;
        _mediator = mediator;
    }

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrEmpty(Solution.Name) || string.IsNullOrEmpty(Solution.SolutionPath))
        {
            return;
        }

        var id = await _solutionRepository.SaveAsync(Solution);
        Solution.Id = id;

        await _mediator.Publish(new NewProjectCreatedNotification(Solution));
    }
}