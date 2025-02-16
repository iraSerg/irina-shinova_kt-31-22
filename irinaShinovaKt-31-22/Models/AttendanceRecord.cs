namespace irinaShinovaKt_31_22.Models
{
    public class AttendanceRecord
    {
        public int AttendanceRecordId { get; set; }

        public int StudentId { get; set; }
        public bool IsPassed { get; set; }

        public virtual Student Student { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
