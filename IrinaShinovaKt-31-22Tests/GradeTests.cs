using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using irinaShinovaKt_31_22.Controllers;
using irinaShinovaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using irinaShinovaKt_31_22.Services;

namespace IrinaShinovaKt_31_22Tests
{
    public class GradeTests
    {
        private readonly Mock<GradeService> _mockService;
        private readonly GradeController _controller;

        public GradeTests()
        {
            _mockService = new Mock<GradeService>();
            _controller = new GradeController(_mockService.Object);
        }

        [Fact]
        public async Task GetGradesForStudent_ReturnsOkWithGrades_WhenSuccess()
        {
            
            int studentId = 1;
            List<GradeRecord> expectedGrades = new List<GradeRecord>
            {
                new GradeRecord { GradeRecordId = 1, Grade = 5, StudentId = 10, SubjectId = 2 },
                new GradeRecord { GradeRecordId = 2, Grade = 4, StudentId = 10, SubjectId = 3 },
                new GradeRecord { GradeRecordId = 3, Grade = 3, StudentId = 10, SubjectId = 4 }
            };

            _mockService.Setup(s => s.GetGradesByStudentId(It.IsAny<int>()))
                        .ReturnsAsync(expectedGrades);

           
            var result = await _controller.GetGradesForStudent(studentId);

            
            var actionResult = Assert.IsType<ActionResult<List<GradeRecord>>>(result);
            var ok = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualGrades = Assert.IsAssignableFrom<List<GradeRecord>>(ok.Value);

            Assert.Equal(expectedGrades.Count, actualGrades.Count);
        }

        [Fact]
        public async Task CreateGrade_ReturnsCreatedAtAction_WhenSuccess()
        {
            GradeRecord newGrade = new GradeRecord { GradeRecordId = 4 };

            _mockService.Setup(s => s.AddGrade(It.IsAny<GradeRecord>()))
                        .ReturnsAsync(newGrade);

            var result = await _controller.CreateGrade(newGrade);


            var actionResult = Assert.IsType<ActionResult<GradeRecord>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            Assert.Equal(4, ((GradeRecord)createdAtActionResult.Value).GradeRecordId);
        }

        [Fact]
        public async Task PutGrade_ReturnsNoContent_WhenUpdateSuccessful()
        {
            int id = 5;
            GradeRecord updatedGrade = new GradeRecord { GradeRecordId = id };

            _mockService.Setup(s => s.UpdateGrade(It.IsAny<GradeRecord>())).ReturnsAsync(updatedGrade);

            IActionResult result = await _controller.PutGrade(id, updatedGrade);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutGrade_ReturnsBadRequest_WhenIdsDoNotEquals()
        {
            int id = 10;
            GradeRecord updatedGrade = new GradeRecord { GradeRecordId = 12 };

            IActionResult result = await _controller.PutGrade(id, updatedGrade);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteGrade_ReturnsNoContent_WhenSuccess()
        {

            int id = 9;

            _mockService.Setup(s => s.DeleteGrade(It.IsAny<int>())).Returns(Task.CompletedTask);

            IActionResult result = await _controller.DeleteGrade(id);

            Assert.IsType<NoContentResult>(result);
        }
    }
}