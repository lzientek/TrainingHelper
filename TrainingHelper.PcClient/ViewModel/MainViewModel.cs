using System;
using System.Timers;
using GalaSoft.MvvmLight;
using TrainingHelper.Models.User;

namespace TrainingHelper.PcClient.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private FullUser _connectedUser;

        public FullUser ConnectedUser
        {
            get { return _connectedUser; }
            set
            {
                _connectedUser = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            var timer = new Timer {Interval = 1000};
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RaisePropertyChanged("Now");
        }

        public void UserConnection(FullUser obj)
        {
            ConnectedUser = obj;
        }
    }
}