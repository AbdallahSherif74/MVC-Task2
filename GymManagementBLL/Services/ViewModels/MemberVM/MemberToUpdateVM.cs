using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementBLL.Services.ViewModels.MemberVM
{
    internal class MemberToUpdateVM
    {
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between 100 and 5 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone Number is Required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Phone Number Must be Egyptian")]
        public string PhoneNumber { get; set; } = null!;
        public int BuildingId { get; set; }
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Street must be between 30 and 5 characters.")]
        [Required(ErrorMessage = "Street is Required")]

        public string? Street { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "City must be between 30 and 2 characters.")]
        [Required(ErrorMessage = "City is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City should contain only Letters and spaces")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "Health Record is Required")]
        public HealthRecord HealthRecord { get; set; } = null!;
    }
}
