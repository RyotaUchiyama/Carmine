using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Carmine
{
    public class BasePage : Page
    {
        public void PageNavigate(string pageName)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Navigate(pageName);

        }

        public void PageNavigate(Uri navigateUri)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Navigate(navigateUri);
        }

        public void PageNavigateMainmenu()
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.NavigateMainmenu();
        }

    }
}
