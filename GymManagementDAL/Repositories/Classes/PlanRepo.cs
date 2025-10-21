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
    internal class PlanRepo : IPlanRepo
    {
        private readonly GymDbContext _dbContext;
        public PlanRepo(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddPlan(Plan plan)
        {
            _dbContext.Plans.Add(plan);
            return _dbContext.SaveChanges();


        }

        public int DeletePlan(int id)
        {
            var plan = _dbContext.Plans.Find(id);
            if (plan == null)
            {
                return 0;
            }
            _dbContext.Plans.Remove(plan);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<Plan> GetAllPlans()
        {
            return _dbContext.Plans.ToList();

        }

        public Plan? GetPlan(int id)
        {
            return _dbContext.Plans.Find(id);

        }

        public int UpdatePlan(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();

        }
    }
}
