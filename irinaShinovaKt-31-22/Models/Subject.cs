using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace irinaShinovaKt_31_22.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<GradeRecord> Grades { get; set; }

        public virtual ICollection<AttendanceRecord> Attendances { get; set; }
    }
}
