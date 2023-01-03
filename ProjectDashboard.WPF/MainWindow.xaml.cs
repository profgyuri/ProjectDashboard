using System.Windows;
using ProjectDashboard.Lib.ViewModels;
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
}