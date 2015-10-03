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
            };
        }
    }
}
