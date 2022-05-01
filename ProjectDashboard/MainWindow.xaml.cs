using System.Windows;
using System.Windows.Controls;
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

        taskbarIcon.Icon = new System.Drawing.Icon("dashboard.ico");
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Visibility = Visibility.Collapsed;
        taskbarIcon.Visibility = Visibility.Visible;
    }

    private void AddStandaloneButton_Click(object sender, RoutedEventArgs e)
    {
        var window = new SettingsWindow();

        if (window.ShowDialog() == true)
        {
            (DataContext as MainWindowViewModel).AddStandalone(window.Result).ConfigureAwait(false);
        }
    }

    private void RemoveItem_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        var entityToRemove = menuItem.Tag as Library.Models.Project;
        var vm = DataContext as MainWindowViewModel;
        vm.RemoveStandalone(entityToRemove).ConfigureAwait(false);
    }

    private void EditItem_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        var menuItem = sender as MenuItem;
        var entityToEdit = menuItem.Tag as Library.Models.Project;
        var unChanged = entityToEdit.Clone();
        var window = new SettingsWindow(entityToEdit);
        if (window.ShowDialog() == true)
        {
            vm.EditStandalone(entityToEdit, window.Result).ConfigureAwait(false);
        }
        else
        {
            menuItem.Tag = unChanged;
        }
    }

    private void taskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
    {
        Visibility = Visibility.Visible;
        taskbarIcon.Visibility = Visibility.Collapsed;
    }

    private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}