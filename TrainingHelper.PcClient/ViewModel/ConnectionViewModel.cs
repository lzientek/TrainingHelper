using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TrainingHelper.DataProvider.User;
using TrainingHelper.Models.User;
using TrainingHelper.PcClient.Annotations;

namespace TrainingHelper.PcClient.ViewModel
{
    public class ConnectionViewModel : ViewModelBase
    {
        private string _pseudo;

        public ConnectionViewModel()
        {

        }

        public string Pseudo
        {
            get { return _pseudo; }
            set
            {
                if (value == _pseudo) return;
                _pseudo = value;
                RaisePropertyChanged();
            }
        }

        #region Methodes

        public async Task<bool> ConnectUser(string password)
        {
            if (string.IsNullOrWhiteSpace(_pseudo))
            {
                throw new Exception("Null pseudo");
            }
            using (var authProvider = new AuthProvider())
            {
                var u = await authProvider.Connect(_pseudo, password);
                if (u == null)
                {
                    return false;
                }
                using (var userProvider = new UserProvider())
                {
                    var user = await userProvider.GetUser(u.Id);
                    OnUserConnection(user);
                }
            }
            return true;
        }

        #endregion



        #region events

        public event Action<FullUser> UserConnection;
        protected virtual void OnUserConnection(FullUser obj)
        {
            UserConnection?.Invoke(obj);
        }

        #endregion






    }
}
