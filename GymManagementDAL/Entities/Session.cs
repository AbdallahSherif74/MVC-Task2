using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Session:BaseEntity
    {
        public string Description { get; set; }= null!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #region relationships

        #region Cat-Session
        public int CategoryID { get; set; }
        public Category SessionCategory { get; set; } = null!;
        #endregion

        #region Session-Trainer
        public int TrainerID { get; set; }
        public Trainer SessionTrainer { get; set; } = null!;
        #endregion
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
    }
}
