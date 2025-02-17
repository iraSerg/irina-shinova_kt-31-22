using irinaShinovaKt_31_22.database.Helpers;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace irinaShinovaKt_31_22.database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(s => s.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder.Property(s => s.SubjectId)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");
            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название предмета");

            builder.ToTable(TableName);

      
            builder.Navigation(s => s.Grades)
                .AutoInclude(false);

            builder.Navigation(s => s.Attendances)
                .AutoInclude(false);
        }
    }
}
