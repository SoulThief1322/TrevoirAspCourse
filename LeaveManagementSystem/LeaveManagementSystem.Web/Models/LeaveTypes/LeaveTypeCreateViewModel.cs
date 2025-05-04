using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
	public class LeaveTypeCreateViewModel
	{
		[Required]
		[Range(1, 90)]
		[Display(Name = "Max number of days")]
		public int NumberOfDays { get; set; }
		[Required]
		[Length(4, 150, ErrorMessage = "You have violated the length requirements")]

		public string Name { get; set; } = string.Empty;
	}
}
