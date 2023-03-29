using System.Windows;
using Autofac;
using ProjectDashboard.Lib.ViewModels;
using ProjectDashboard.WPF.Dependency;
using ProjectDashboard.WPF.Layouts;

namespace ProjectDashboard.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        LayoutContentControl.Content = new Layout1();

        DataContext = viewModel;
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void NewProjectButton_Click(object sender, RoutedEventArgs e)
    {
        var container = AutofacContainer.Container;
        var window = container.Resolve<SolutionEditWindow>();
        window.ShowDialog();
    }
}