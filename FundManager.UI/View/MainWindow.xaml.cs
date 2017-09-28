using FundManager.UI.ViewModel;
using System.Windows;

namespace FundManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainViewModel;
        public MainWindow(MainWindowViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
        }
    }
}
