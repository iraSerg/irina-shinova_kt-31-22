using irinaShinovaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using irinaShinovaKt_31_22.Exceptions;
using irinaShinovaKt_31_22.database;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace irinaShinovaKt_31_22.Services
{
    public class GroupServiceImpl : GroupService
    {
        private readonly StudentDbContext _context;

        public GroupServiceImpl(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> CreateGroup(Group group)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task DeleteGroup(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new GroupNotFoundException("Группа не найдена");
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            var existingGroup = await _context.Groups.FindAsync(group.GroupId);
            if (existingGroup == null)
            {
                throw new GroupNotFoundException("Группа не найдена");
            }

            existingGroup.GroupName = group.GroupName;
            await _context.SaveChangesAsync();
            return existingGroup;
        }
    }
}