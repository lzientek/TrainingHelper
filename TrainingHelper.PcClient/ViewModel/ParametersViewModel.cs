using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Timers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TrainingHelper.Models.User;

namespace TrainingHelper.PcClient.ViewModel
{

    public class ParametersViewModel : ViewModelBase
    {
        private ObservableCollection<string> _serverPath;
        private int _serverPort;

        public ObservableCollection<string> ServerPath
        {
            get { return _serverPath; }
            private set { _serverPath = value; RaisePropertyChanged(); }
        }

        public int ServerPort
        {
            get { return _serverPort; }
            set { _serverPort = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ParametersViewModel()
        {
            ServerPath = new ObservableCollection<string>();
            ServerPort = App.ApiServer.Port;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList.Where(address => !address.IsIPv6LinkLocal))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ServerPath.Add($"http://{ip}:{ServerPort}");
                }
            }
        }

    }
}