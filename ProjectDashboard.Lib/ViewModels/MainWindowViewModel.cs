namespace ProjectDashboard.Lib.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

[INotifyPropertyChanged]
public partial class MainWindowViewModel
{
    [ObservableProperty] private ObservableCollection<string> projectNames;

	public MainWindowViewModel()
	{
		projectNames = new()
		{
			"Multitasking",
			"Music Listening",
			"Something, that is hopefully too long for 2 lines, so the text will be trimmed."
		};
	}
}