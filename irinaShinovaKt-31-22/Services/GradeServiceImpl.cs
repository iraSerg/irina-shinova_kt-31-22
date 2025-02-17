using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using irinaShinovaKt_31_22.database;
using irinaShinovaKt_31_22.Exceptions;

namespace irinaShinovaKt_31_22.Services
{
    public class GradeServiceImpl : GradeService
    {
        private readonly StudentDbContext _context;

        public GradeServiceImpl(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GradeRecord>> GetGradesByStudentId(int studentId)
        {
            return await _context.GradeRecords.Where(g => g.StudentId == studentId).ToListAsync();
        }
        public async Task<GradeRecord> AddGrade(GradeRecord grade)
        {
            _context.GradeRecords.Add(grade);
            await _context.SaveChangesAsync(); 
            return grade;
        }
        public async Task<GradeRecord> UpdateGrade(GradeRecord grade)
        {
            var existingGrade = await _context.GradeRecords.FindAsync(grade.GradeRecordId);
            if (existingGrade == null)
            {
                throw new GradeNotFoundException("Оценка не найдена");
            }
            else
            {
                existingGrade.Grade = grade.Grade;
            }
            await _context.SaveChangesAsync(); 
            return grade;
        }
        public async Task DeleteGrade(int gradeId)
        {
            var grade = await _context.GradeRecords.FindAsync(gradeId);
            if (grade == null)
            {
                throw new GradeNotFoundException("Оценка не найдена");
            }

            _context.GradeRecords.Remove(grade);
            await _context.SaveChangesAsync();
            
        }
    }
}
