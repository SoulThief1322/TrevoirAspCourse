using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
	public class LeaveTypeReadOnlyVM : BaseLeaveTypeViewModel
	{
		public string Name { get; set; } = string.Empty;
		[Display(Name = "Max number of days")]

		public int NumberOfDays { get; set; }
	}
}
