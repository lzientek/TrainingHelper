namespace TrainingHelper.PcClient.Common
{
    public class ObjectManipulation<T>
    {
        public ObjectManipulation(T value, Manipulation manip )
        {
            Manipulation = manip;
            Value = value;
        }

        public Manipulation Manipulation { get; set; }
        public T Value { get; set; }
    }
}