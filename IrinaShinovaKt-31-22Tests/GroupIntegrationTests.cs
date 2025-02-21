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
    public class GroupIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> dbContextOptions;
        public readonly StudentDbContext context;
        public GroupIntegrationTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "student_db")
                .Options;
            context = new StudentDbContext(dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task AddGroup_SuccessfullyAddsGroupToTheDatabase()
        {

            var group = new Group { GroupId = 1, GroupName = "kt-31-22" };

            context.Groups.Add(group);
            await context.SaveChangesAsync();


            var addedGroup = await context.Groups.FirstOrDefaultAsync(g => g.GroupId == group.GroupId);
            Assert.NotNull(addedGroup);
            Assert.Equal(group.GroupName, addedGroup.GroupName);
        }
        [Fact]
        public async Task UpdateGroup_SuccessfullyUpdatesExistingGroup()
        {

            var existingGroup = new Group { GroupId = 1, GroupName = "kt-31-22" };
            context.Groups.Add(existingGroup);
            await context.SaveChangesAsync();

            existingGroup.GroupName = "kt-41-22";
            context.Groups.Update(existingGroup);
            await context.SaveChangesAsync();

            var updatedGroup = await context.Groups.FindAsync(existingGroup.GroupId);
            Assert.Equal("kt-41-22", updatedGroup.GroupName);
        }
        public async Task DeleteGroup_RemovesGroupFromTheDB()
        {

            var groupToDelete = new Group { GroupId = 1, GroupName = "kt-31-22" };
            context.Groups.Add(groupToDelete);
            await context.SaveChangesAsync();

            context.Groups.Remove(groupToDelete);
            await context.SaveChangesAsync();


            var deletedGroup = await context.Groups.FindAsync(groupToDelete.GroupId);
            Assert.Null(deletedGroup);
        }

    }
}
