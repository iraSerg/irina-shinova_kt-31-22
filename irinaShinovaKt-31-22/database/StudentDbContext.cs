using irinaShinovaKt_31_22.database.Configurations;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace irinaShinovaKt_31_22.database
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public  DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GradeRecord> GradeRecords { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GradeRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceRecordConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options) { 
            
        }
    }
}
