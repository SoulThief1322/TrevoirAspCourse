using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
	public class LeaveTypeEditViewModel : BaseLeaveTypeViewModel
	{
		[Required]
		[Length(4, 150, ErrorMessage = "Length requirements")]
		public string Name { get; set; } = string.Empty;
		[Required]
		[Range(1,90)]
		public int NumberOfDays { get; set; }
	}
}
