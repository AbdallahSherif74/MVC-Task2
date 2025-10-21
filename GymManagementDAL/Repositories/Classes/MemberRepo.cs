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
    internal class MemberRepo : IMemberRepo
    {
        private readonly GymDbContext _dbContext;
        public MemberRepo(GymDbContext _dbContext) { 
            
            this._dbContext = _dbContext;
        }

        public int AddMember(Member member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();

        }

        public int DeleteMember(int id)
        {
           var member= _dbContext.Members.Find(id);
            if (member==null)
            {
                return 0;
            }
            _dbContext.Members.Remove(member);
           return _dbContext.SaveChanges();
            
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _dbContext.Members.ToList();
        }

        public Member? GetMember(int id)
        {
            return _dbContext.Members.Find(id);
        }

        public int UpdateMember(Member member)
        {
            _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}
