using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities.Enums;

namespace GymManagementDAL.Entities
{
    public class Trainer:GymUser
    {
        public Speciallities speciallities { get; set; }


        public ICollection<Session> Sessions { get; set; } = null!;

    }
}
