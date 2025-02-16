using irinaShinovaKt_31_22.database.Configurations;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace irinaShinovaKt_31_22.database
{
    public class StudentDbContext: DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }

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
