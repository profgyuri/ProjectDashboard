using System.Windows;
using ProjectDashboard.Library.ViewModels;

namespace ProjectDashboard;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void AddStandaloneButton_Click(object sender, RoutedEventArgs e)
    {
        var window = new SettingsWindow();

        if (window.ShowDialog() == true)
        {
            (DataContext as MainWindowViewModel).AddStandalone(window.Result);
        }
    }
}