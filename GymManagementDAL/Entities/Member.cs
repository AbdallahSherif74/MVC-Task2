﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class Member:GymUser
    {
        public string? photo { get; set; }

        #region relationships

        #region Member-HealthRecord
        public HealthRecord HealthRecord { get; set; }=null!;
        #endregion
        #region Member-Membership
        public ICollection<Membership> Memberships { get; set; }= null!;
        #endregion
        #region Member-MemberSession
        public ICollection<MemberSession>MemberSessions  { get; set; } = null!;
        #endregion

        #endregion
    }
}
