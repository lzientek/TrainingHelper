namespace TrainingHelper.Models.Programs
{
    public class ShortProgram: IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbUser { get; set; }
        public int? Difficulty { get; set; }
        public int NbExercises { get; set; }
    }
}
