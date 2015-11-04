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

        public async Task<FullExerciseNL> CreateExercise(FullExerciseNL exercise)
        {
            var exe = exercise.ToNewTrainingExercise();
            _db.TrainingExercise.Add(exe);
            int i = await _db.SaveChangesAsync();
            return exe.ToFullExerciseNL();
        }

        #endregion


        #region Get

        public async Task<IEnumerable<MadeExercisesShort>> GetMadeExercices(int userId)
        {
            var list = await _db.MadeExercises.Where(me => me.UserId == userId).ToListAsync();
            return list.ToMadeExercisesShort();
        }

        public async Task<IEnumerable<FullExerciseNL>> GetAllExercises()
        {
            var list = await _db.TrainingExercise.ToListAsync();
            return list.ToFullExercises();
        }

        public async Task<FullExercise> GetFullExercise(int id,int actualUser)
        {
            var exercise = await _db.TrainingExercise.FindAsync(id);
            exercise.MadeExercises = _db.MadeExercises.Where(me => me.UserId == actualUser).ToList();
            return exercise.ToFullExercise();
        }

        #endregion

        #region Save
        public async Task<FullExercise> SaveExercise(FullExerciseNL exercise)
        {
            var toUpdate = await _db.TrainingExercise.FindAsync(exercise.Id);
            toUpdate.UpdateExercise(exercise);
            int i = await _db.SaveChangesAsync();
            return toUpdate.ToFullExercise();
        }


        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }


        
    }
}
