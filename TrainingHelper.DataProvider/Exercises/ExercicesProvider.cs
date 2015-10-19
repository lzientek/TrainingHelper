using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Core.ModelConverter;
using TrainingHelper.DataProvider.User;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;
using UserInfos = TrainingHelper.Models.User.UserInfos;

namespace TrainingHelper.DataProvider.Exercises
{
    public class ExercicesProvider:IDisposable
    {
        private DatabaseEntities _db;

        public ExercicesProvider()
        {
            _db = new DatabaseEntities();
        }
        #region create

        #endregion


        #region Get

        public async Task<IEnumerable<MadeExercisesShort>> GetMadeExercices(int userId)
        {
            var list = await _db.MadeExercises.Where(me => me.UserId == userId).ToListAsync();
            return list.ToMadeExercisesShort();
        }

        #endregion


        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
