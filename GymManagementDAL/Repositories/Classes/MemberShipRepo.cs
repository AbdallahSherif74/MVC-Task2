using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    internal class MemberShipRepo : IMemberShipRepo
    {
        private readonly GymDbContext _dbContext;
        public MemberShipRepo(GymDbContext dbContext) {
        
            _dbContext = dbContext;
        }
        public int AddMemberShip(Membership memberShip)
        {
            _dbContext.Memberships.Add(memberShip);
            return _dbContext.SaveChanges();
        }

        public int DeleteMemberShip(int id)
        {
            var memberShip = _dbContext.Memberships.Find(id);
            if (memberShip == null)
            {
                return 0;
            }
            _dbContext.Memberships.Remove(memberShip);
            return _dbContext.SaveChanges();


        }

        public IEnumerable<Membership> GetAllMemberShips()
        {
            return _dbContext.Memberships.ToList();

        }

        public Membership? GetMemberShip(int id)
        {
            return _dbContext.Memberships.Find(id);

        }

        public int UpdateMemberShip(Membership memberShip)
        {
            _dbContext.Memberships.Update(memberShip);
            return _dbContext.SaveChanges();

        }
    }
}
