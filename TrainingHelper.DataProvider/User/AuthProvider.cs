using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Core.ModelConverter;
using TrainingHelper.Models.User;

namespace TrainingHelper.DataProvider.User
{
    public class AuthProvider:IDisposable
    {
        private DatabaseEntities _db;
        public AuthProvider()
        {
            _db = new DatabaseEntities();
        }

        public async Task<ConnectionUser> Connect(string pseudo, string password)
        {
            password = EncryptPassword(password);
            var usr = _db.User.FirstOrDefault(u => u.Pseudo == pseudo && u.EncriptedPassword == password);
            if (usr == null)
            {
                return null;
            }
            usr.LastConnection = DateTime.Now;
           int i =await _db.SaveChangesAsync();
            return usr.ToConnectionUser();
        }



        #region static methods

        internal static string EncryptPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
