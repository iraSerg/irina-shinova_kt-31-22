using irinaShinovaKt_31_22.database.Helpers;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace irinaShinovaKt_31_22.database.Configurations
{
    public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        private const string TableName = "cd_attendance_record";

        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
            builder
                .HasKey(ar => ar.AttendanceRecordId)
                .HasName($"pk_{TableName}_attendance_record_id");

            builder.Property(ar => ar.AttendanceRecordId)
                .ValueGeneratedOnAdd();
            builder.Property(ar => ar.AttendanceRecordId)
                .HasColumnName("attendance_record_id")
                .HasComment("Идентификатор записи зачета");
            builder.Property(ar => ar.StudentId)
                .IsRequired()
                .HasColumnName("student_id")
                .HasComment("Идентификатор студента");
            builder.Property(ar => ar.SubjectId)
                .IsRequired()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");
            builder.Property(ar => ar.IsPassed)
                .IsRequired()
                .HasColumnName("c_is_passed")
                .HasColumnType(ColumnType.Bool)
                .HasDefaultValue(false)
                .HasComment("Зачет/Незачет");

            builder.HasOne(ar => ar.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(ar => ar.StudentId)
                .HasConstraintName("fk_cd_attendance_record_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ar => ar.Subject)
                .WithMany(s => s.Attendances)
                .HasForeignKey(ar => ar.SubjectId)
                .HasConstraintName("fk_cd_attendance_record_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName);

            
            builder.Navigation(ar => ar.Student)
                .AutoInclude(false);

            builder.Navigation(ar => ar.Subject)
                .AutoInclude(false);

        }

    }
}
