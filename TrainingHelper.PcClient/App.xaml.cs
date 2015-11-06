using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using TrainingHelper.Models.User;
using TrainingHelper.PcClient.ViewModel;
using TrainingHelper.StandaloneApiServer;

namespace TrainingHelper.PcClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Server ApiServer { get; set; }
        public static ViewModelLocator ViewModelLocator => (ViewModelLocator)Current.Resources["Locator"];

        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                ApiServer = Server.Launch("http://localhost", 8888);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("{0}{1}{2}{3}", 
                    ex.Message, 
                    ex.StackTrace, 
                    ex.InnerException?.Message??string.Empty, 
                    ex.InnerException?.StackTrace??string.Empty), "Unexpected Error");
            }


        }
    }
}
