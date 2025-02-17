namespace irinaShinovaKt_31_22.Exceptions
{
    public class GradeNotFoundException:Exception
    {
        public GradeNotFoundException() : base("Оценка не найдена.")
        {
        }
        public GradeNotFoundException(string message) : base(message)
        {
        }
        public GradeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
