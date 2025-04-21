using AutoMapper;
using LeaveManagementSystem.Web.Data.Models;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
			//.ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays));

			CreateMap<LeaveTypeCreateViewModel, LeaveType>();
			CreateMap<LeaveTypeEditViewModel, LeaveType>().ReverseMap();
		}
	}
}
