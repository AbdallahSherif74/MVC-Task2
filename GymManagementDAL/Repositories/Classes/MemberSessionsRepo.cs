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
    internal class MemberSessionsRepo : IMemberSessionRepo
    {
        private readonly GymDbContext _dbContext;
        public MemberSessionsRepo(GymDbContext dbContext) {
        
            _dbContext = dbContext;
        }
        public int AddMemberSession(MemberSession memberSession)
        {
            _dbContext.MemberSessions.Add(memberSession);
            return _dbContext.SaveChanges();


        }

        public int DeleteMemberSession(int id)
        {
            var memberSession = _dbContext.MemberSessions.Find(id);
            if (memberSession == null)
            {
                return 0;
            }
            _dbContext.MemberSessions.Remove(memberSession);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<MemberSession> GetAllMemberSessions()
        {
            return _dbContext.MemberSessions.ToList();

        }

        public MemberSession? GetMemberSession(int id)
        {
            return _dbContext.MemberSessions.Find(id);

        }

        public int UpdateMemberSession(MemberSession memberSession)
        {
            _dbContext.MemberSessions.Update(memberSession);
            return _dbContext.SaveChanges();
        }
    }
}
