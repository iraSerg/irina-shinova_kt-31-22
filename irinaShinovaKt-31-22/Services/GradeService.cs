using irinaShinovaKt_31_22.Models;

namespace irinaShinovaKt_31_22.Services
{
    public interface GradeService
    {
        Task<IEnumerable<GradeRecord>> GetGradesByStudentId(int studentId);
        Task<GradeRecord> AddGrade(GradeRecord grade);
        Task<GradeRecord> UpdateGrade(GradeRecord grade);
        Task DeleteGrade(int gradeId);
    }
}
