using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Models.Programs;

namespace TrainingHelper.Models.Exercises
{
    public class FullExercise:FullExerciseNL
    {
        public IEnumerable<MadeExercisesShort> MadeExercises { get; set; }
        public IEnumerable<ShortProgram> Programs { get; set; }
    }
}
