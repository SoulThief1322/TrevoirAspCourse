using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Data.Models;
using LeaveManagementSystem.Web.Contracts;

namespace LeaveManagementSystem.Web.Services
{
    public class LeaveTypesService : ILeaveTypesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync()
        {
            var data = await _context.LeaveTypes.ToListAsync();
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (leaveType == null)
            {
                return null;
            }
            var viewData = _mapper.Map<T>(leaveType);
            return viewData;
        }

        public async Task Remove(int id)
        {
            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(LeaveTypeEditViewModel leaveTypeEdit)
        {
            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == leaveTypeEdit.Id);
            if (leaveType != null)
            {
                leaveType.Name = leaveTypeEdit.Name;
                leaveType.NumberOfDays = leaveTypeEdit.NumberOfDays;
                _context.LeaveTypes.Update(leaveType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Create(LeaveTypeCreateViewModel leaveTypeCreate)
        {
            if (await CheckIfNameAlreadyExists(leaveTypeCreate.Name))
            {
                return false;
            }
            var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
            await _context.LeaveTypes.AddAsync(leaveType);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public async Task<bool> CheckIfNameAlreadyExists(string name)
        {
            var lowerCaseName = name.ToLower();
            return await _context.LeaveTypes.AnyAsync(x => x.Name.ToLower().Equals(lowerCaseName));
        }

        public async Task<bool> CheckIfEditNameExists(LeaveTypeEditViewModel leaveTypeEdit)
        {
            var lowerCaseName = leaveTypeEdit.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(x => x.Name.ToLower().Equals(lowerCaseName) && x.Id != leaveTypeEdit.Id);
        }
    }
}
