using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface IPlanRepo
    {
        //GetAllPlans
        IEnumerable<Plan> GetAllPlans();
        //GetPlanById
        Plan? GetPlan(int id);
        //AddPlan
        int AddPlan(Plan plan);
        //UpdatePlan
        int UpdatePlan(Plan plan);
        //DeletePlan
        int DeletePlan(int id);
    }
}
