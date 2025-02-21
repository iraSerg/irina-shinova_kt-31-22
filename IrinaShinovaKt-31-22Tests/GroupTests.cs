using irinaShinovaKt_31_22.Controllers;
using irinaShinovaKt_31_22.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using irinaShinovaKt_31_22.Controllers;
using irinaShinovaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrinaShinovaKt_31_22Tests
{
    public class GroupTests
    {
        private readonly Mock<ILogger<GroupController>> _mockLogger;
        private readonly Mock<GroupService> _mockService;
        private readonly GroupController _controller;

        public GroupTests()
        {
            _mockLogger = new Mock<ILogger<GroupController>>();
            _mockService = new Mock<GroupService>();
            _controller = new GroupController(_mockLogger.Object, _mockService.Object);
        }

        [Fact]
        public async Task GetGroups_ReturnsOkWithGroups_WhenSuccess()
        {

            IEnumerable<Group> expectedGroups = new List<Group>
            {
                new Group { GroupId = 11 ,GroupName="kt-31-22"},
                new Group { GroupId = 12,GroupName="kt-41-22" }
            };

            _mockService.Setup(s => s.GetAllGroups())
                        .ReturnsAsync(expectedGroups);
            var result = await _controller.GetGroups();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Group>>>(result);

            var okR = Assert.IsType<OkObjectResult>(actionResult.Result);

            var actualGroups = Assert.IsAssignableFrom<IEnumerable<Group>>(okR.Value);

            Assert.Equal(expectedGroups.Count(), actualGroups.Count());
        }

        [Fact]
        public async Task CreateNewGroup_ReturnsCreatedAtAction_WhenSuccess()
        {

            Group newGroup = new Group { GroupId = 3 };

            _mockService.Setup(s => s.CreateGroup(It.IsAny<Group>()))
                        .ReturnsAsync(newGroup);
            var result = await _controller.CreateNewGroup(newGroup);

  
            var actionResult = Assert.IsType<ActionResult<Group>>(result);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            Assert.Equal(3, ((Group)createdAtActionResult.Value).GroupId);
        }

        [Fact]
        public async Task DeleteGroup_ReturnsNoContent_WhenSuccess()
        {

            int id = 1;

            _mockService.Setup(s => s.DeleteGroup(It.IsAny<int>())).Returns(Task.CompletedTask);

            IActionResult result = await _controller.DeleteGroup(id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteGroup_ReturnsBadRequest_WhenExceptionThrown()
        {

            int id = 15;
            string errorMessage = "Группа не найдена.";

            _mockService.Setup(s => s.DeleteGroup(It.IsAny<int>()))
                        .Throws(new Exception(errorMessage));

 
            IActionResult result = await _controller.DeleteGroup(id);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateGroup_ReturnsNoContent_WhenIdsMatchAndUpdateSuccessful()
        {
            int id = 6;
            Group updatedGroup = new Group { GroupId = id, GroupName = "kt-31-22" };

            _mockService.Setup(s => s.UpdateGroup(It.IsAny<Group>())).ReturnsAsync(updatedGroup);

 
            IActionResult result = await _controller.UpdateGroup(id, updatedGroup);

            Assert.IsType<NoContentResult>(result);
        }
    }
}