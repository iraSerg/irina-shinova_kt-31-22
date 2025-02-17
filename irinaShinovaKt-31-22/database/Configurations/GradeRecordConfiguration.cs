using irinaShinovaKt_31_22.database.Helpers;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace irinaShinovaKt_31_22.database.Configurations
{
    public class GradeRecordConfiguration : IEntityTypeConfiguration<GradeRecord>
    {
        private const string TableName = "cd_grade_record";

        public void Configure(EntityTypeBuilder<GradeRecord> builder)
        {
            builder
                .HasKey(gr => gr.GradeRecordId)
                .HasName($"pk_{TableName}_grade_record_id");

            builder.Property(gr => gr.GradeRecordId)
                .ValueGeneratedOnAdd();
            builder.Property(gr => gr.GradeRecordId)
                .HasColumnName("grade_record_id")
                .HasComment("Идентификатор оценки");
            builder.Property(gr => gr.StudentId)
                .IsRequired()
                .HasColumnName("student_id")
                .HasComment("Идентификатор студента");
            builder.Property(gr => gr.SubjectId)
                .IsRequired()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");
            builder.Property(gr => gr.Grade)
                .IsRequired()
                .HasColumnName("c_grade_value")
                .HasColumnType(ColumnType.Int)
                .HasComment("Оценка студента");

            builder.HasOne(gr => gr.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(gr => gr.StudentId)
                .HasConstraintName("fk_cd_grade_record_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gr => gr.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(gr => gr.SubjectId)
                .HasConstraintName("fk_cd_grade_record_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName);

         
            builder.Navigation(gr => gr.Student)
                .AutoInclude(false);

            builder.Navigation(gr => gr.Subject)
                .AutoInclude(false);
        }
    }
}
