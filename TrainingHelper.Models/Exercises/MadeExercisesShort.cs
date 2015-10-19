using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Models.User;

namespace TrainingHelper.Models.Exercises
{
    public class MadeExercisesShort
    {
        public int Id { get; set; }
        public ShortExercise Exercise { get; set; }
        public DateTime Date { get; set; }
        public string AdditionnalInfo { get; set; }
        public SmallUser User { get; set; }
        public int NbSeries { get; set; }
    }
}
