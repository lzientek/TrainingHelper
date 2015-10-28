using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.Programs;

namespace TrainingHelper.Core.ModelConverter
{
    public static partial class DatabaseToClass
    {
        public static IEnumerable<ShortProgram> ToShortPrograms(this IEnumerable<TrainingProgram> prog)
        {
            return prog.Select(ToShortPrograms);
        }

        public static ShortProgram ToShortPrograms(this TrainingProgram prog)
        {
            return new ShortProgram()
            {
                Id = prog.Id,
                Name = prog.Name,
                NbUser = prog.UserToProgram.Count,
                Difficulty=prog.Difficulty,
                NbExercises = prog.TrainingProgramToExercise.Count,
            };
        }

        public static ShortProgram ToShortPrograms(this TrainingProgramToExercise trainingProgramToExercise)
        {
            return trainingProgramToExercise.TrainingProgram.ToShortPrograms();
        }
        public static IEnumerable<ShortProgram> ToShortPrograms(this IEnumerable<TrainingProgramToExercise> trainingProgramToExercise)
        {
            return trainingProgramToExercise.Select(ToShortPrograms);
        }
    }
}
