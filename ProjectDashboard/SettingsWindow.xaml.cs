using System.Windows;
using Microsoft.Win32;
using ProjectDashboard.Library.Models;
using ProjectDashboard.Library.ViewModels;

namespace ProjectDashboard;

/// <summary>
///     Interaction logic for SettingsWindow.xaml
/// </summary>
public partial class SettingsWindow : Window
{
    private string _previousPath;
    public Project Result { get; set; }

    public SettingsWindow()
    {
        InitializeComponent();

        SetDefaults(null);
    }

    public SettingsWindow(Project project)
    {
        InitializeComponent();

        SetDefaults(project);
    }

    private void SetDefaults(Project project)
    {
        var context = DataContext as SettingsWindowViewModel;
        context.ProjectObject = project ?? new Project();

        if (string.IsNullOrEmpty(context.ProjectObject.ProjectName))
        {
            context.NameFieldVisible = true;
            context.Height = 350;
        }
        else
        {
            context.NameFieldVisible = false;
            context.Height = 290;
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Result = (DataContext as SettingsWindowViewModel).ProjectObject;

        if (!string.IsNullOrEmpty(Result?.ProjectName ?? ""))
        {
            DialogResult = true;
            Close();
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private string GetPathFromFileBrowser(string filter)
    {
        var dialog = new OpenFileDialog
        {
            Filter = filter,
            InitialDirectory = _previousPath ?? string.Empty
        };

        if (dialog.ShowDialog() == true)
        {
            var path = dialog.FileName;
            _previousPath = path;
            return path;
        }

        return null;
    }

    private void PublishedButton_Click(object sender, RoutedEventArgs e)
    {
        var context = DataContext as SettingsWindowViewModel;
        context.ProjectObject.PublishPath = GetPathFromFileBrowser("Executables (*.exe)|*.exe");
    }

    private void DebugButton_Click(object sender, RoutedEventArgs e)
    {
        var context = DataContext as SettingsWindowViewModel;
        context.ProjectObject.DebugPath = GetPathFromFileBrowser("Executables (*.exe)|*.exe");
    }

    private void ReleaseButton_Click(object sender, RoutedEventArgs e)
    {
        var context = DataContext as SettingsWindowViewModel;
        context.ProjectObject.ReleasePath = GetPathFromFileBrowser("Executables (*.exe)|*.exe");
    }

    private void SolutionButton_Click(object sender, RoutedEventArgs e)
    {
        var context = DataContext as SettingsWindowViewModel;
        context.ProjectObject.ReleasePath = GetPathFromFileBrowser("Solution files (*.sln)|*.sln");
    }
}