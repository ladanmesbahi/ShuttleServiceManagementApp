using System.ComponentModel.DataAnnotations;

namespace ShuttleServiceManagementApp.Shared.Requests
{
    public sealed class RegisterBusRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود نام راننده الزامی است.")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "ورود ظرفیت الزامی است.")]
        [Range(minimum: 1, maximum: 50, ErrorMessage = "ورود ظرفیت الزامی است.")]
        public int Capacity { get; set; }
    }
}
