using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace TrainingHelper.StandaloneApiServer
{
    public class Server : IDisposable
    {
        private IDisposable _webApp;
        public bool IsLaunch { get; private set; }
        public int Port { get; private set; }
        public string Url { get; private set; }
        private Server(IDisposable webApp)
        {
            _webApp = webApp;
            IsLaunch = true;
        }
        public static Server Launch(string url, int port)
        {
            return new Server(WebApp.Start<Startup>($"{url}:{port}")) { Port = port, Url = url };
        }

        public void Dispose()
        {
            IsLaunch = false;
            _webApp.Dispose();
        }
    }
}
