using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Globalization;
using VisitorApp.Model;
using VisitorApp.View;

namespace VisitorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Window _currentWindow;

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            // Change startup window
            _currentWindow = new LoginWindow();
            //_currentWindow = new MainWindow();
            _currentWindow.ShowDialog();
        }
    }
}
