using ProjectDashboard.Lib.Models;
using ProjectDashboard.Lib.ViewModels;
using System.Windows;

namespace ProjectDashboard.WPF
{
    /// <summary>
    /// Interaction logic for SolutionEditWindow.xaml
    /// </summary>
    public partial class SolutionEditWindow : Window
    {
        public Solution Solution 
        {
            get
            {
                var vm = (SolutionEditWindowViewModel)DataContext;
                return vm.Solution;
            }
            set
            {
                var vm = (SolutionEditWindowViewModel)DataContext;
                vm.Solution = value;
                vm.IsEditingOnly = true;
            }
        }

        public SolutionEditWindow(SolutionEditWindowViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
