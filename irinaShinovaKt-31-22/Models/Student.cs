﻿using System.Text.RegularExpressions;

namespace irinaShinovaKt_31_22.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
        public virtual ICollection<GradeRecord> Grades { get; set; }

        public virtual ICollection<AttendanceRecord> Attendances { get; set; }
    }
}
