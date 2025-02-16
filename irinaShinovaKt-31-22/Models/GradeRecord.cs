namespace irinaShinovaKt_31_22.Models
{

    public class GradeRecord
    {
        public int GradeRecordId { get; set; }
        public int Grade { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
