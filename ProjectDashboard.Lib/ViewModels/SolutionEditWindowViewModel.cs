using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Lib.Models;
using ProjectDashboard.Lib.Repositories;

namespace ProjectDashboard.Lib.ViewModels;

[INotifyPropertyChanged]
public partial class SolutionEditWindowViewModel
{
    private readonly ISolutionRepository _solutionRepository;

    [ObservableProperty] private Solution _solution;

    public bool IsEditingOnly { get; set; }

    public SolutionEditWindowViewModel(ISolutionRepository solutionRepository)
    {
        Solution = new Solution()
        {
            Name = "New Solution",
            SolutionPath = @"C:\Path\To\Your.sln"
        };
        _solutionRepository = solutionRepository;
    }

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrEmpty(Solution.Name) || string.IsNullOrEmpty(Solution.SolutionPath))
        {
            return;
        }

        await _solutionRepository.SaveAsync(Solution);
    }
}