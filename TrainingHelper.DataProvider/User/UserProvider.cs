using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Core.ModelConverter;
using TrainingHelper.Models.User;
using UserInfos = TrainingHelper.Models.User.UserInfos;

namespace TrainingHelper.DataProvider.User
{
    public class UserProvider:IDisposable
    {
        public const int UserRole = 1;
        public const int AdminRole = 2;
        private DatabaseEntities _db;
        public UserProvider()
        {
            _db = new DatabaseEntities();
        }
        #region create

        public async Task<FullUser> CreateUser(CreateUser user)
        {
            Core.DbConnection.User u = new Core.DbConnection.User()
            {
                BirthDate = user.BirthDate,
                CreationDate = DateTime.Now,
                EncriptedPassword = AuthProvider.EncryptPassword(user.Password),
                Pseudo = user.Pseudo,
                FirstName = user.FirstName,
                LastConnection = DateTime.Now,
                LastName = user.LastName,
            };
            u.UserInRole.Add(new UserInRole() {RoleId = UserRole });
            _db.User.Add(u);
            int i = await  _db.SaveChangesAsync();
            return u.ToFullUser();
        }
        #endregion


        #region Get

        public async Task<IEnumerable<UserInfos>> GetUserInfos(int userId)
        {
            var user= await _db.User.FindAsync(userId);
            return user?.UserInfo.ToUserInfos();
        }

        #endregion


        public void Dispose()
        {
            _db.Dispose();
        }


        public async Task<IEnumerable<SmallUser>> GetUsers()
        {
            return await _db.User.Select(u => new SmallUser {Id = u.Id, Pseudo = u.Pseudo}).ToListAsync();
        }
    }
}
