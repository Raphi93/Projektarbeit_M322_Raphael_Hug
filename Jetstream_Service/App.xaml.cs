using JetStream_Service.Properties;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace JetStream_Service
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LanguageID);
        }
    }
}
