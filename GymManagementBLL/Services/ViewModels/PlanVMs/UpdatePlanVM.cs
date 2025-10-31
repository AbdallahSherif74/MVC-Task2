using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.ViewModels.PlanVMs
{
    internal class UpdatePlanVM
    {
        [Required(ErrorMessage = "Plan Name is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Plan Name must be between 50 and 2 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Plan Name should contain only Letters and spaces")]
        public string PlanName { get; set; }=null!;
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Description must be between 50 and 2 characters.")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "DurationDays is Required")]
        [Range(1, 365 , ErrorMessage = "DurationDays must be greater than 0 and less than or equal 365")]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

    }
}
