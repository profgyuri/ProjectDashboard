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
}