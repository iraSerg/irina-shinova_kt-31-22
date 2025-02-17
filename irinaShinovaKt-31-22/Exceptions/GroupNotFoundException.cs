namespace irinaShinovaKt_31_22.Exceptions
{
    public class GroupNotFoundException:Exception
    {
        public GroupNotFoundException() : base("Группа не найдена.")
        {
        }
        public GroupNotFoundException(string message) : base(message)
        {
        }
        public GroupNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
