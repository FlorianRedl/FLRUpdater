using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FLRUpdater;

namespace Tester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Updater.Logo = @"C:\Users\Florian\source\repos\FLRUpdater\Logo\flr-studios Logo.png";
            Updater.OnStartUp(@"C:\Users\Florian\source\repos\FLRUpdater\VersionDB.xml");

            var mainWindow = new MainWindow();
            //Re-enable normal shutdown mode.
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Current.MainWindow = mainWindow;
            mainWindow.Show();

        }

       


    }
}
