using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;

namespace TrainingHelper.Core.ModelConverter
{
    public static partial class Class2Database
    {
        public static TrainingExercise ToNewTrainingExercise(this FullExerciseNL exercise)
        {
            var exe = exercise.ToTrainingExercise();
            exe.CreationDate = DateTime.Now;
            exe.ModificationDate = null;
            return exe;
        }

        public static TrainingExercise ToTrainingExercise(this FullExerciseNL exercise)
        {
            return new TrainingExercise()
            {
                Name = exercise.Name,
                Description = exercise.Description,
                PhotoPath = exercise.PhotoPath,
                Id = exercise.Id,
            };
        }
    }
}
