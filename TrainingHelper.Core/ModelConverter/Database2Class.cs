using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Models.User;


namespace TrainingHelper.Core.ModelConverter
{
    public static class Database2Class
    {
        public static ConnectionUser ToConnectionUser(this User user)
        {
            return new ConnectionUser()
            {
                Pseudo = user.Pseudo,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastConnection = user.LastConnection,
                Id = user.Id,
                LastName = user.LastName,
                Roles = user.UserInRole?.Select(r => r.Roles.Role),
            };
        }
        public static FullUser ToFullUser(this User user)
        {
            return new FullUser()
            {
                Pseudo = user.Pseudo,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastConnection = user.LastConnection,
                Id = user.Id,
                LastName = user.LastName,
                Roles = user.UserInRole?.Select(r => r.Roles.Role),
                LastModificationDate = user.LastModification,
                CreationDate = user.CreationDate

            };
        }

        public static IEnumerable<UserInfos> ToUserInfos(this ICollection<UserInfo> usrInfo)
        {
            return usrInfo.Select(info => new UserInfos()
            {
                CreationDate = info.CreationDate,
                AveragePulse= info.AveragePulse,
                Id = info.Id,
                UserId = info.UserId,
                Feeling = info.Feeling,
                Height = info.Height,
                Weight = info.Weight,
            });
        }
    }
}
