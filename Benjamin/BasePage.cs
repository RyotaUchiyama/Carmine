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
        private string pageName = string.Empty;
        public string PageName
        {
            get
            {
                return pageName;
            }
        }

        private string assemblyName = string.Empty;
        public string AssemblyName
        {
            get
            {
                return assemblyName;
            }
        }

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
