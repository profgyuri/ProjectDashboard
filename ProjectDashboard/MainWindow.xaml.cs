namespace ProjectDashboard;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ProjectDashboard.Library.ViewModels;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        taskbarIcon.Icon = new System.Drawing.Icon("dashboard.ico");

        var vm = DataContext as MainWindowViewModel;
        var integrateds = vm.Integrated;
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
            (DataContext as MainWindowViewModel)!.AddStandalone(window.Result).ConfigureAwait(false);
        }
    }

    private void RemoveItem_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        var entityToRemove = menuItem!.Tag as Library.Models.Standalone;
        var vm = DataContext as MainWindowViewModel;
        vm!.RemoveStandalone(entityToRemove!).ConfigureAwait(false);
    }

    private void EditItem_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        var menuItem = sender as MenuItem;
        var entityToEdit = menuItem!.Tag as Library.Models.Standalone;
        var unChanged = entityToEdit!.Clone();
        var window = new SettingsWindow(entityToEdit);
        if (window.ShowDialog() == true)
        {
            vm!.EditStandalone(entityToEdit, window.Result).ConfigureAwait(false);
        }
        else
        {
            menuItem.Tag = unChanged;
        }
    }

    private void ShowWindow_Click(object sender, RoutedEventArgs e)
    {
        Visibility = Visibility.Visible;
        taskbarIcon.Visibility = Visibility.Collapsed;
    }

    private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ToggleButton_Checked(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        var asToggleButton = sender as ToggleButton;
        var project = asToggleButton!.Tag as Library.Models.Integrated;
        vm!.StartIntegrated(project!).ConfigureAwait(false);
    }

    private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        var asToggleButton = sender as ToggleButton;
        var project = asToggleButton!.Tag as Library.Models.Integrated;
        vm!.StopIntegratedAsync(project!).ConfigureAwait(false);
    }

    private void StartWithWindowsMenuItem_OnChecked(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        vm.StartsWithWindows = true;
    }

    private void StartWithWindowsMenuItem_OnUnchecked(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        vm.StartsWithWindows = false;
    }
}