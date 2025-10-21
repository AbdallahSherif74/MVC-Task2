using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Membership:BaseEntity
    {
        public DateTime EndDate { get; set; }
        public string Satus
        {
            get {                 
                if (EndDate < DateTime.UtcNow)
                {
                    return "Expired";
                }
                return "Active";
            }
        }
        public int MemberId { get; set; }
        public Member Member { get; set; }= null!;
        public Plan Plan { get; set; }= null!;
        public int PlanId { get; set; }
    }
}
