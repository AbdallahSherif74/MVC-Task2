using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.ViewModels.MemberVM
{
    internal class HealthRecordVM
    {
        [Required(ErrorMessage = "Height is Required")]
        [Range(0.1, 300, ErrorMessage = "Height must be between 0.1 cm and 300 cm")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Weight is Required")]
        [Range(0.1, 500, ErrorMessage = "Weight must be between 0.1 kg and 500 kg")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Blood Type is Required")]
        [StringLength(3, ErrorMessage = "Blood Type must be between 3 or 1 less.")]

        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }
    }
}
