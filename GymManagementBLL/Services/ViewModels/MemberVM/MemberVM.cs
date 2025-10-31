using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementBLL.Services.ViewModels.MemberVM
{
    internal class MemberVM
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Email { get; set; }= null!;
        public string? PhotoUrl { get; set; }
        
        public string Gender { get; set; }= null!;
        public string? PlanName { get; set; }  
        public string? DateOfBirth { get; set; }
        public string? MemberShipStartDate { get; set; }
        public string? MemberShipEndDate { get; set; }
        public string? address { get; set; }= null!;

    }
}
