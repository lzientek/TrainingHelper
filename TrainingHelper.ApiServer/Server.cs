using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace TrainingHelper.StandaloneApiServer
{
    public class Server:IDisposable
    {
        private IDisposable _webApp;

        private Server(IDisposable webApp)
        {
            _webApp = webApp;
        }
        public static Server Launch(string url, int port)
        {
            return new Server(WebApp.Start<Startup>($"{url}:{port}"));

        }

        public void Dispose()
        {
            _webApp.Dispose();
        }
    }
}
