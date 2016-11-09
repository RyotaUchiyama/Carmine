using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carmine
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationService navi;

        public MainWindow()
        {
            InitializeComponent();
            initializeSetting();
        }

        private void initializeSetting()
        {
            this.DataContext = MainWindowViewModel.Instance;
            this.navi = MainFrame.NavigationService;
        }

        public void Navigate(string pageName)
        {
            this.Navigate(Controller.Instance.GetPageUri(pageName));
        }

        public void Navigate(Uri pageUri)
        {
            this.navi.Navigate(pageUri);
        }

        public void NavigateMainmenu()
        {
            this.navi.Navigate(Controller.Instance.Mainmenu);
        }
        

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigateMainmenu();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
