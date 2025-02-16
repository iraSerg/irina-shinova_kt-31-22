using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace irinaShinovaKt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subject_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_attendance_record",
                columns: table => new
                {
                    attendance_record_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор студента"),
                    c_is_passed = table.Column<bool>(type: "bool", nullable: false, defaultValue: false, comment: "Зачет/Незачет"),
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_attendance_record_attendance_record_id", x => x.attendance_record_id);
                    table.ForeignKey(
                        name: "fk_cd_attendance_record_student_id",
                        column: x => x.student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_attendance_record_subject_id",
                        column: x => x.subject_id,
                        principalTable: "cd_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade_record",
                columns: table => new
                {
                    grade_record_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_grade_value = table.Column<int>(type: "int4", nullable: false, comment: "Оценка студента"),
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор студента"),
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_record_grade_record_id", x => x.grade_record_id);
                    table.ForeignKey(
                        name: "fk_cd_grade_record_student_id",
                        column: x => x.student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_grade_record_subject_id",
                        column: x => x.subject_id,
                        principalTable: "cd_subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_attendance_record_student_id",
                table: "cd_attendance_record",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_attendance_record_subject_id",
                table: "cd_attendance_record",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_record_student_id",
                table: "cd_grade_record",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_record_subject_id",
                table: "cd_grade_record",
                column: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_attendance_record");

            migrationBuilder.DropTable(
                name: "cd_grade_record");

            migrationBuilder.DropTable(
                name: "cd_subject");
        }
    }
}
