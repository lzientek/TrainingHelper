using System;

namespace TrainingHelper.Models.Exercises
{
    /// <summary>
    /// Full exercises object NL for no link
    /// </summary>
    public class FullExerciseNL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}