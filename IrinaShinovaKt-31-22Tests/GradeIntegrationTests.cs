using irinaShinovaKt_31_22.database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irinaShinovaKt_31_22.Controllers;
using irinaShinovaKt_31_22.Models;

namespace IrinaShinovaKt_31_22Tests
{
    public class GradeIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> dbContextOptions;
        public readonly StudentDbContext context;
        public GradeIntegrationTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "student_db")
                .Options;
            context = new StudentDbContext(dbContextOptions);
            context.Database.EnsureDeleted();  
            context.Database.EnsureCreated();
        }
      
        [Fact]
        public async Task AddGradeRecord_SuccessfullyAddsGradeRecordToTheDatabase()
        {
            
            var subject = new Subject { SubjectId = 1, Name = "Programming" };
            var student = new Student { StudentId = 1, FirstName = "Ivan", MiddleName = "Ivanovich", LastName = "Ivanov" };
            var gradeRecord = new GradeRecord
            {
                GradeRecordId = 1,
                Grade = 5,
                StudentId = student.StudentId,
                Student = student,
                SubjectId = subject.SubjectId,
                Subject = subject
            };

            
            context.GradeRecords.Add(gradeRecord);
            await context.SaveChangesAsync();

            
            var addedGradeRecord = await context.GradeRecords.FirstOrDefaultAsync(gr => gr.GradeRecordId == gradeRecord.GradeRecordId);
            Assert.NotNull(addedGradeRecord);
            Assert.Equal(gradeRecord.Grade, addedGradeRecord.Grade);
            Assert.Equal(gradeRecord.StudentId, addedGradeRecord.StudentId);
            Assert.Equal(gradeRecord.SubjectId, addedGradeRecord.SubjectId);
        }
        [Fact]
        public async Task UpdateGradeRecord_SuccessfullyUpdatesExistingGradeRecord()
        {
            
            var subject = new Subject { SubjectId = 1, Name = "Database" };
            var student = new Student { StudentId = 1, FirstName = "Ivan", MiddleName = "Ivanovich", LastName = "Ivanov" };
            var existingGradeRecord = new GradeRecord
            {
                GradeRecordId = 1,
                Grade = 4,
                StudentId = student.StudentId,
                Student = student,
                SubjectId = subject.SubjectId,
                Subject = subject
            };

            context.Students.Add(student);
            context.Subjects.Add(subject);
            context.GradeRecords.Add(existingGradeRecord);
            await context.SaveChangesAsync();

           
            existingGradeRecord.Grade = 5;
            context.GradeRecords.Update(existingGradeRecord);
            await context.SaveChangesAsync();

            
            var updatedGradeRecord = await context.GradeRecords.FindAsync(existingGradeRecord.GradeRecordId);
            Assert.Equal(5, updatedGradeRecord.Grade);
        }
        [Fact]
        public async Task DeleteGradeRecord_RemovesGradeRecordFromTheDatabase()
        {
           
            var subject = new Subject { SubjectId = 1, Name = "1C" };
            var student = new Student { StudentId = 1, FirstName = "Ivan", MiddleName = "Ivanovich", LastName = "Ivanov" };
            var gradeRecordToDelete = new GradeRecord
            {
                GradeRecordId = 1,
                Grade = 4,
                StudentId = student.StudentId,
                Student = student,
                SubjectId = subject.SubjectId,
                Subject = subject
            };

            context.Students.Add(student);
            context.Subjects.Add(subject);
            context.GradeRecords.Add(gradeRecordToDelete);
            await context.SaveChangesAsync();

           
            context.GradeRecords.Remove(gradeRecordToDelete);
            await context.SaveChangesAsync();

         
            var deletedGradeRecord = await context.GradeRecords.FindAsync(gradeRecordToDelete.GradeRecordId);
            Assert.Null(deletedGradeRecord);
        }
    }
}
