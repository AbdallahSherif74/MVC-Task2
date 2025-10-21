using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface IMemberRepo
    {
        //GetAllMembers
        IEnumerable<Member> GetAllMembers();
        //GetMemberById
        Member? GetMember(int id);

        //AddMember
        int AddMember(Member member);
        //UpdateMember
        int UpdateMember(Member member);
        //DeleteMember
        int DeleteMember(int id);



    }
}
