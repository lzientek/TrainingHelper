using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Models.User;

namespace TrainingHelper.Core.ModelConverter
{
    public static class Class2Database
    {
        public static IEnumerable<UserInfo> ToDbUserInfo(this IEnumerable<UserInfos> usrInfo)
        {
            return usrInfo.Select(ToDbUserInfo);
        }

        private static UserInfo ToDbUserInfo(this UserInfos info)
        {
            return new UserInfo()
            {
                CreationDate = info.CreationDate,
                AveragePulse = info.AveragePulse,
                Id = info.Id,
                UserId = info.UserId,
                Feeling = info.Feeling,
                Height = info.Height,
                Weight = info.Weight,
            };
        }
    }
}
