using Microsoft.Extensions.Configuration;
using ProjektReolmarked.Database;
using System.Configuration;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows;


namespace ProjektReolmarked
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    // Test commit
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseInitializer databaseInitializer =
                new DatabaseInitializer();

            databaseInitializer.Initialize();
        }
    }


}
