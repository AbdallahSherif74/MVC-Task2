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
    internal class SessionRepo: ISessionRepo
    {
        private readonly GymDbContext _dbContext;
        public SessionRepo(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddSession(Session session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int DeleteSession(int id)
        {
            var session = _dbContext.Sessions.Find(id);
            if (session == null)
            {
                return 0;
            }
            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<Session> GetAllSessions()
        {
            return _dbContext.Sessions.ToList();
        }

        public Session? GetSession(int id)
        {
            return _dbContext.Sessions.Find(id);


        }

        public int UpdateSession(Session session)
        {
            _dbContext.Sessions.Update(session);
            return _dbContext.SaveChanges();

        }
    }
}
