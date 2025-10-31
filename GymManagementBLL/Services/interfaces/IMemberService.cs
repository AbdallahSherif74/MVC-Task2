using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.ViewModels.MemberVM;

namespace GymManagementBLL.Services.interfaces
{
    internal interface IMemberService
    {
        IEnumerable<MemberVM> GetAllMembers();
        bool createMember(CreateMemberVM member);
        MemberVM? GetMemberDetails(int id);
        HealthRecordVM? GetMemberHealthRecord(int memberId);
        MemberToUpdateVM? UpdateMember(MemberVM member);
        bool UpdateMemberDetails(int memberId, MemberToUpdateVM member);
        bool DeleteMember(int memberId);
    }
}
