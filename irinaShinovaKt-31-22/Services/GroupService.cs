using irinaShinovaKt_31_22.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace irinaShinovaKt_31_22.Services
{
    public interface GroupService
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<Group> CreateGroup(Group group);
        Task DeleteGroup(int id);
        Task<Group> UpdateGroup(Group group);
    }
}