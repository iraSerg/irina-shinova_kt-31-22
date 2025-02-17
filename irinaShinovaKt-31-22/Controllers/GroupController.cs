using irinaShinovaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using irinaShinovaKt_31_22.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace irinaShinovaKt_31_22.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> logger;
        private readonly GroupService _groupService;

        public GroupController(ILogger<GroupController> logger, GroupService groupService)
        {
            this.logger = logger;
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await _groupService.GetAllGroups();
            return Ok(groups);
        }
        [HttpPost]
        public async Task<ActionResult<Group>> CreateNewGroup([FromBody] Group group)
        {
            var newGroup = await _groupService.CreateGroup(group);

            return CreatedAtAction(nameof(CreateNewGroup), new { id = group.GroupId }, group);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {


            try
            {
                await _groupService.DeleteGroup(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Group group)
        {

            if (id != group.GroupId)
            {
                return BadRequest();
            }

            try
            {
                var updatedGroup = await _groupService.UpdateGroup(group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
