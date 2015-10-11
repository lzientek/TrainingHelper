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

        }

        public void UserConnection(FullUser obj)
        {
            ConnectedUser = obj;
        }
    }
}