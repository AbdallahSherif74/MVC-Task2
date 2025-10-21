using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface IMemberShipRepo
    {
        //GetAllMemberShips
        IEnumerable<Membership> GetAllMemberShips();
        //GetMemberShipById
        Membership? GetMemberShip(int id);
        //AddMemberShip
        int AddMemberShip(Membership memberShip);
        //UpdateMemberShip
        int UpdateMemberShip(Membership memberShip);
        //DeleteMemberShip
        int DeleteMemberShip(int id);
    }
}
