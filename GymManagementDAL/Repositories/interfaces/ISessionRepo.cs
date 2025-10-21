using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface ISessionRepo
    {
        //GetAllSessions
        IEnumerable<Session> GetAllSessions();
        //GetSessionById
        Session? GetSession(int id);
        //AddSession
        int AddSession(Session session);
        //UpdateSession
        int UpdateSession(Session session);
        //DeleteSession
        int DeleteSession(int id);


    }
}
