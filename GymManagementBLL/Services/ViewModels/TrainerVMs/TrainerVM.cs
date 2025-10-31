using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using GymManagementDAL.Entities.Enums;

namespace GymManagementBLL.Services.ViewModels.TrainerVMs
{
    internal class TrainerVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; }=null!;
        public string Speciallities { get; set; }=null!;
        public int City { get; set; }

    }
}
