using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using TrainingHelper.StandaloneApiServer;

namespace TrainingHelper.PcClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Server ApiServer { get; set; }

        public App()
        {
            ApiServer = Server.Launch("http://localhost", 8888);

        }
    }
}
