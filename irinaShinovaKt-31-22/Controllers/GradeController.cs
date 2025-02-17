using irinaShinovaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using irinaShinovaKt_31_22.Services;
using Microsoft.EntityFrameworkCore;
namespace irinaShinovaKt_31_22.Controllers
{
    [ApiController]
    [Route("api/grade")]
    public class GradeController:ControllerBase 
    {
        private readonly GradeService _service;

        public GradeController(GradeService service)
        {
            _service = service;
        }
        [HttpGet("{studentId}")]
        public async Task<ActionResult<List<GradeRecord>>> GetGradesForStudent(int studentId)
        {
            try
            {
                var grades = await _service.GetGradesByStudentId(studentId);
                return Ok(grades.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<GradeRecord>> CreateGrade([FromBody] GradeRecord grade)
        {
            try
            {
                await _service.AddGrade(grade);
                return CreatedAtAction(nameof(CreateGrade), new { id = grade.GradeRecordId }, grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, [FromBody] GradeRecord grade)
        {
            if (id != grade.GradeRecordId)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateGrade(grade);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
                await _service.DeleteGrade(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
