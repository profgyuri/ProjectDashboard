using CommunityToolkit.Mvvm.ComponentModel;
using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib.ViewModels;

[INotifyPropertyChanged]
public partial class SolutionEditWindowViewModel
{
    [ObservableProperty] private Solution _solution;
    
    public SolutionEditWindowViewModel()
    {
        Solution = new Solution()
        {
            Name = "New Solution",
            SolutionPath = @"C:\Path\To\Your.sln"
        };
    }
}