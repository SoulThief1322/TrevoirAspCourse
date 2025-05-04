using LeaveManagementSystem.Web.Models;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Contracts
{
    public interface ILeaveTypesService
    {
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync();
        Task<T?> Get<T>(int id) where T : class;
        Task Remove(int id);
        Task Edit(LeaveTypeEditViewModel leaveTypeEdit);
        Task<bool> Create(LeaveTypeCreateViewModel leaveTypeCreate);
        bool LeaveTypeExists(int id);
        Task<bool> CheckIfNameAlreadyExists(string name);
        Task<bool> CheckIfEditNameExists(LeaveTypeEditViewModel leaveTypeEdit);
    }
}