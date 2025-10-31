using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.ViewModels.PlanVMs;

namespace GymManagementBLL.Services.interfaces
{
    internal interface IPlanService
    {
        IEnumerable<PlanVM> GetAllPlans();
        PlanVM? GetPlanDetails(int id);
        UpdatePlanVM? GetPlanForUpdate(int id);
        bool UpdatePlan(int id, UpdatePlanVM updatePlanVM);
        bool TogglePlanStatus(int id);



    }
}
