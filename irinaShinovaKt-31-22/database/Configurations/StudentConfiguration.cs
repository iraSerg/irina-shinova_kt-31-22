using irinaShinovaKt_31_22.database.Helpers;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.RateLimiting;

namespace irinaShinovaKt_31_22.database.Configurations
{
    public class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String) 
                .HasMaxLength(100)
                .HasComment("Фамилия студента");
            builder.Property(p => p.MiddleName)
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String) 
                .HasMaxLength(100)
                .HasComment("Отчество студента");
            builder.Property(p => p.GroupId)
              .IsRequired()
              
              .HasColumnName("group_id")
              .HasComment("Идентификатор группы");

            builder.HasOne(s => s.Group)
                .WithMany() 
                .HasForeignKey(s => s.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.HasMany(s => s.Grades)
               .WithOne(g => g.Student)
               .HasForeignKey(g => g.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Attendances)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Group)
                .AutoInclude();
            builder.Navigation(p => p.Grades)
                .AutoInclude(false);
            builder.Navigation(p => p.Attendances)
                .AutoInclude(false);

        }
    }
    
    
}
