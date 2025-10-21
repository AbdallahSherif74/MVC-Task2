using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface IMemberSessionRepo
    {
        //GetAllMemberSessions
        IEnumerable<MemberSession> GetAllMemberSessions();
        //GetMemberSessionById
        MemberSession? GetMemberSession(int id);
        //AddMemberSession
        int AddMemberSession(MemberSession memberSession);
        //UpdateMemberSession
        int UpdateMemberSession(MemberSession memberSession);
        //DeleteMemberSession
        int DeleteMemberSession(int id);
    }
}
