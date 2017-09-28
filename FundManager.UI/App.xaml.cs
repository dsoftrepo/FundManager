using System.Windows;
using Autofac;
using FundManager.UI.Startup;

namespace FundManager.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var dependencies = new Dependencies();
            var container = dependencies.BuildContainer();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
