using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Models.Exercises;

namespace TrainingHelper.Core.ModelConverter
{
    public static partial class DatabaseToClass
    {

        public static IEnumerable<MadeExercisesShort> ToMadeExercisesShort(this IEnumerable<MadeExercises> dbExercises)
        {
            return dbExercises.Select(exercise => exercise.ToMadeExercises());
        }

        public static MadeExercisesShort ToMadeExercises(this MadeExercises dbExe)
        {
            return new MadeExercisesShort()
            {
                Id = dbExe.Id,
                AdditionnalInfo = dbExe.AdditionnalInfo,
                Date = dbExe.Date,
                NbSeries = dbExe.MadeSeries.Count,
                Exercise = dbExe.TrainingExercise.ToShortExercise(),
                User = dbExe.User.ToSmallUser(),
            };
        }

        public static ShortExercise ToShortExercise(this TrainingExercise dbExe)
        {
            return new ShortExercise()
            {
                Id = dbExe.Id,
                Name = dbExe.Name,
            };
        }
    }
}
