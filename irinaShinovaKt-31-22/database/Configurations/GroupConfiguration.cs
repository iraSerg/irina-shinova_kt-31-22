using irinaShinovaKt_31_22.database.Helpers;
using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.RateLimiting;

namespace irinaShinovaKt_31_22.database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(g => g.GroupId)
                .HasName($"pk_{TableName}_group_id");

            builder.Property(g => g.GroupId)
                .ValueGeneratedOnAdd();
            builder.Property(g => g.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");
            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String)
                .HasComment("Название группы");

            builder.ToTable(TableName);
        }
    }
}